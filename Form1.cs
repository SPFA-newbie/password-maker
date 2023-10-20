using System.Collections;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasswordMaker
{
    public partial class Main : Form
    {
        public const string seedFileName = "seed";
        public const string extraFileName = "extra";
        public const int seedSize = 4096;

        private byte[] seed;
        private bool emptyInput;
        private AntiMemoryScan safeSaver;

        public Main()
        {
            InitializeComponent();

            // Read Seed
            if (File.Exists(seedFileName))
            {
                using(BinaryReader reader = new BinaryReader(File.OpenRead(seedFileName))) 
                {
                    seed = reader.ReadBytes(seedSize);
                }
                
                // Set Enabled
                seedMaker.Enabled = false;
                seedClear.Enabled = true;
                outputButton.Enabled = true;
            }
            else
            {
                seed = new byte[1];// nop

                // Set Enabled
                seedMaker.Enabled = true;
                seedClear.Enabled = false;
                outputButton.Enabled = false;
            }

            // Create SafeSaver
            safeSaver = new AntiMemoryScan();

            // Read ExtraMessage And Write ExtraMessage To ComboBox
            readExtraMessage();

            // Init InputBox
            emptyInput = true;
        }

        private void seedMaker_Click(object sender, EventArgs e)
        {
            // Make Seed
            seed=new byte[seedSize];
            Random r = new Random();
            r.NextBytes(seed);

            // Write Seed
            File.Create(seedFileName).Close();
            using(BinaryWriter writer = new BinaryWriter(File.OpenWrite(seedFileName)))
            {
                writer.Write(seed);
            }

            // SetButton
            seedMaker.Enabled = false;
            seedClear.Enabled = true;
            outputButton.Enabled = true;

            // Message
            MessageBox.Show("种子生成完毕", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void seedClear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定删除？删除后将不可恢复！", 
                               "Danger", 
                               MessageBoxButtons.YesNo, 
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                // Delete Seed File
                File.Delete(seedFileName);

                // Set Enabled
                seedMaker.Enabled = true;
                seedClear.Enabled = false;
                outputButton.Enabled = false;
            }
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            if (!outputTimer.Enabled)
            {
                if (safeSaver.getLength() == 0)
                {
                    MessageBox.Show("未输入密钥!", "Key is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!(Symbol.Checked || Digit.Checked || Lowcase.Checked || Capital.Checked))
                {
                    MessageBox.Show("未选择字符集!", "Empty Set of Char", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    outputTimer.Start();
                    outputButton.Text = "取消(Cancel)";
                }
            }
            else
            {
                outputTimer.Stop();
                outputButton.Text = "输出密码(Output)";
            }
        }

        private void outputTimer_Tick(object sender, EventArgs e)
        {
            // Lock
            outputTimer.Stop();
            outputButton.Enabled = false;
            this.Enabled = false;
            outputButton.Text = "输出中...";

            // Work
            PasswordMakerTool.Work(seed, safeSaver.outputSHA256(seed), (ExtraMessage)tagName.SelectedItem);

            // Clear & Reset
            safeSaver.clear();
            setLengthTip();
            tagName.SelectedIndex = 0;
            this.Enabled = true;
            outputButton.Text = "输出密码(Output)";
        }

        private void clearPassword_Click(object sender, EventArgs e)
        {
            safeSaver.clear();
            setLengthTip();
            emptyInput = true;
            PasswordInput.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (tagName.Text == "")
                MessageBox.Show("标签不能为空！", "Name Can`t Be Empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                // Get Message
                ExtraMessage extra = new ExtraMessage();
                extra.name = tagName.Text;
                extra.length = (int)passwordLength.Value;
                extra.message = extraMessage.Text;
                extra.symbol = Symbol.Checked;
                extra.digit = Digit.Checked;
                extra.lowercase = Lowcase.Checked;
                extra.capital = Capital.Checked;

                // Refresh ComboBox
                if (tagName.SelectedIndex <= 0)
                {
                    tagName.Items.Add(extra);
                    tagName.SelectedIndex = tagName.Items.Count - 1;
                }
                else
                    tagName.Items[tagName.SelectedIndex] = extra;

                // Save
                writeExtraMessage();

            }
        }

        private void tagName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tagName.Text == "")
            {
                tagName.DropDownStyle = ComboBoxStyle.DropDown;
                deleteButton.Enabled = false;
                outputButton.Enabled = false;
            }
            else
            {
                tagName.DropDownStyle= ComboBoxStyle.DropDownList;
                deleteButton.Enabled = true;
                outputButton.Enabled = true;
            }

            ExtraMessage extra = (ExtraMessage)tagName.SelectedItem;
            passwordLength.Value = extra.length;
            extraMessage.Text = extra.message;
            Symbol.Checked = extra.symbol;
            Digit.Checked = extra.digit;
            Lowcase.Checked = extra.lowercase;
            Capital.Checked = extra.capital;
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Delete in List
            int nowSelect = tagName.SelectedIndex;
            tagName.SelectedIndex = 0;
            tagName.Items.RemoveAt(nowSelect);

            // Save
            writeExtraMessage();
        }

        private void readExtraMessage()
        {
            // Clear And Write a Empty Message To ComboBox
            tagName.Items.Clear();
            tagName.Items.Add(new ExtraMessage());
            tagName.SelectedIndex = 0;

            // Test File
            if (!File.Exists(extraFileName))
                File.Create(extraFileName).Close();

            // Read File
            ExtraMessage[]? tempArray = null;
            string fileMessage = File.ReadAllText(extraFileName);
            if (fileMessage.Length != 0)
            {
                try
                {
                    tempArray = JsonSerializer.Deserialize<ExtraMessage[]>(fileMessage);
                }catch(JsonException exception)
                {
                    string errorMessage = "附加信息文件出错，将清除附加信息文件内容！";
                    if (exception != null)
                        errorMessage += "\n------------------------------------\n详细信息：\n" + exception.Message;
                    MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    writeExtraMessage();
                }
            }

            // Write ExtraMessage To ComboBox
            if(tempArray!=null)
                foreach (ExtraMessage message in tempArray)
                    tagName.Items.Add(message);
        }

        private void writeExtraMessage() 
        {
            if (!File.Exists(extraFileName))
                File.Create(extraFileName).Close();

            ExtraMessage[] tempArray;
            tempArray = new ExtraMessage[tagName.Items.Count-1];
            for (int i = 1; i < tagName.Items.Count; i++)
                tempArray[i-1] = (ExtraMessage)tagName.Items[i];

            File.WriteAllText(extraFileName, JsonSerializer.Serialize(tempArray));
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            if (PasswordInput.Text.Length == 1)
            {
                if (emptyInput)
                    safeSaver.addNewChar(PasswordInput.Text[0]);
                emptyInput = false;
            }else if(PasswordInput.Text.Length == 2)
            {
                if (safeSaver.getLength() == AntiMemoryScan.maxLength)
                {
                    MessageBox.Show("已达到最大长度，新输入的字符将被舍弃", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PasswordInput.Text = "" + PasswordInput.Text[0];
                }
                else
                {
                    safeSaver.addNewChar(PasswordInput.Text[1]);
                    PasswordInput.Text = "" + PasswordInput.Text[1];
                }
                emptyInput = false;
            }
            else if(safeSaver.getLength() != 0)
            {
                safeSaver.removeChar(safeSaver.getLength());
                if (safeSaver.getLength() != 0)
                {
                    PasswordInput.Text = "?";
                    emptyInput = false;
                }
                else
                    emptyInput = true;
            }
            setLengthTip();
            PasswordInput.Select(PasswordInput.TextLength, 0);
        }

        private void setLengthTip()
        {
            keyLengthTip.Text = "已输入" + safeSaver.getLength() + "位";
        }
    }
}