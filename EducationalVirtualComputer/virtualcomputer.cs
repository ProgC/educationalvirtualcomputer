// https://www.youtube.com/user/MidnightKiyoung
// 2016/6/24, ProgC

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalVirtualComputer
{
    public partial class virtualcomputer : Form
    {
        List<MemoryVariable> MemoryList = new List<MemoryVariable>();
                
        // Machine related variables.        
        int InstructionIndex = 0;
        int MaxInstructionIndex = 0;
        DateTime StartTime = new DateTime();
        DateTime DelayTime = new DateTime();
        bool EnableDelay = false;
        int LoopStartIndex = 0;
        bool AnimStart = false;

        //160x144
        //const int monitorWidthSize = 160;
        //const int monitorHeightSize = 144;
        const int monitorWidthSize = 200;
        const int monitorHeightSize = 200;
        public Color[,] MonitorPixels = new Color[monitorHeightSize, monitorWidthSize];
        
        public class Code
        {
            public enum Type
            {
                CLEAR_MONITOR,
                ASSIGN,
                PUTPIXEL,
                LOOPSTART,
                LOOPEND,
                ADD,
                SUB,                
                DELAY
            }
            
            public int CodeIndex;
            public Type CodeType;
            public string Target;

            public enum ValueType
            {
                CONSTANT,
                VARIABLE
            }

            public ValueType valueType;
            public int intValue;
            public float floatValue;
            public string stringValue;

            public Code(int inCodeIndex, Type inCodeType)
            {
                CodeIndex = inCodeIndex;
                CodeType = inCodeType;
            }
        }

        List<Code> CodeList = new List<Code>();

        public virtualcomputer()
        {
            InitializeComponent();
        }

        private void monitor_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = monitor.Width;
            int height = monitor.Height;
            int gridSize = 20;
            //int gridSize = 4;

            int monitorWidth = monitorWidthSize / gridSize;
            int monitorHeight = monitorHeightSize / gridSize;

            for (int y = 0; y < monitorHeight; ++y)
            {
                for (int x = 0; x < monitorWidth; ++x)
                {
                    SolidBrush newBrush = new SolidBrush(MonitorPixels[y,x]);
                    g.FillRectangle(newBrush, x * gridSize, y * gridSize, gridSize, gridSize);
                    newBrush.Dispose();
                }
            }

            Pen blackPen = new Pen(Brushes.Black);
            for (int y = 0; y < height; y += gridSize)
            {
                g.DrawLine(blackPen, 0, y, width, y);

                for (int x = 0; x < width; x += gridSize)
                {
                    g.DrawLine(blackPen, x, 0, x, height);
                }
            }

            g.DrawLine(blackPen, width-1, 0, width-1, height);
            g.DrawLine(blackPen, 0, height - 1, width - 1, height - 1);
            blackPen.Dispose();
        }

        private string INT1;
        private string INT2;
        private string FLOAT1;
        private string FLOAT2;
        private string STRING1;
        private string STRING2;
        private string LOOP;
        private string COLOR;
        private string COLOR_RED;
        private string COLOR_GREEN;
        private string COLOR_BLUE;
        private string UI_VARIABLE_NAME;
        private string UI_VARIABLE_TYPE;
        private string UI_VARIABLE_VALUE;

        private string UI_MONITOR;
        private string UI_CODE;
        private string UI_CPU_INFO;
        private string UI_INSTRUCTION_NUMBER;
        private string UI_TIME;
        private string UI_SPEED;
        private string UI_COLOR_PALATTE;
        private string UI_MEMORY_INFO;

        private string COMMAND_ASSIGN;
        private string COMMAND_PUTPIXEL;
        private string COMMAND_LOOPSTART;
        private string COMMAND_LOOPEND;
        private string COMMAND_ADD;
        private string COMMAND_SUB;
        private string COMMAND_CLEAR;
        private string COMMAND_DELAY;

        private string WARNING_CANT_USE_VARIABLE_VALUE;
        private string WARNING_DOESNT_EXIST_COMMAND;
        private string WARNING_CANT_ASSIGN_TO_SAME_VARIABLE;
        private string WARNING_CANT_CONVERT;
        private string WARNING_DOESNT_EXIST;

        private string UI_CODE_ANIMATION;

        private string ANI_ASSIGN_SOMETING;
        private string ANI_OF_VALUE;
        private string ANI_INCREASE_SOMETING;
        private string ANI_DECREASE_SOMETING;
        
        private void LoadLanguageSetting()
        {
            if ( comboBoxLanguageSetting.Text.Equals("한글") )
            {
                INT1 = Properties.Resources.INT1;
                INT2 = Properties.Resources.INT2;
                FLOAT1 = Properties.Resources.FLOAT1;
                FLOAT2 = Properties.Resources.FLOAT2;
                STRING1 = Properties.Resources.STRING1;
                STRING2 = Properties.Resources.STRING2;
                LOOP = Properties.Resources.LOOP;
                COLOR = Properties.Resources.COLOR;
                COLOR_RED = Properties.Resources.COLOR_RED;
                COLOR_GREEN = Properties.Resources.COLOR_GREEN;
                COLOR_BLUE = Properties.Resources.COLOR_BLUE;

                // change ui's strings
                btnRun.Text = Properties.Resources.UI_EXECUTE;
                
                UI_VARIABLE_NAME = Properties.Resources.UI_VARIABLE_NAME;
                UI_VARIABLE_TYPE = Properties.Resources.UI_VARIABLE_TYPE;
                UI_VARIABLE_VALUE = Properties.Resources.UI_VARIABLE_VALUE;

                UI_MONITOR = Properties.Resources.UI_MONITOR;
                UI_CODE = Properties.Resources.UI_CODE;
                UI_CPU_INFO = Properties.Resources.UI_CPU_INFO;
                UI_INSTRUCTION_NUMBER = Properties.Resources.UI_INSTRUCTION_NUMBER;
                UI_TIME = Properties.Resources.UI_TIME;
                UI_SPEED = Properties.Resources.UI_SPEED;
                UI_COLOR_PALATTE = Properties.Resources.UI_COLOR_PALATTE;
                UI_MEMORY_INFO = Properties.Resources.UI_MEMORY_INFO;

                COMMAND_ASSIGN = Properties.Resources.COMMAND_ASSIGN;
                COMMAND_PUTPIXEL = Properties.Resources.COMMAND_PUTPIXEL;
                COMMAND_LOOPSTART = Properties.Resources.COMMAND_LOOPSTART;
                COMMAND_LOOPEND = Properties.Resources.COMMAND_LOOPEND;
                COMMAND_ADD = Properties.Resources.COMMAND_ADD;
                COMMAND_SUB = Properties.Resources.COMMAND_SUB;
                COMMAND_CLEAR = Properties.Resources.COMMAND_CLEAR;
                COMMAND_DELAY = Properties.Resources.COMMAND_DELAY;

                WARNING_CANT_USE_VARIABLE_VALUE = Properties.Resources.WARNING_CANT_USE_VARIABLE_VALUE;
                WARNING_DOESNT_EXIST_COMMAND = Properties.Resources.WARNING_DOESNT_EXIST_COMMAND;
                WARNING_CANT_ASSIGN_TO_SAME_VARIABLE = Properties.Resources.WARNING_CANT_ASSIGN_TO_SAME_VARIABLE;
                WARNING_CANT_CONVERT = Properties.Resources.WARNING_CANT_CONVERT;
                WARNING_DOESNT_EXIST = Properties.Resources.WARNING_DOESNT_EXIST;

                UI_CODE_ANIMATION = Properties.Resources.UI_CODE_ANIMATION;

                ANI_ASSIGN_SOMETING = Properties.Resources.ANI_ASSIGN_SOMETING;
                ANI_OF_VALUE = Properties.Resources.ANI_OF_VALUE;
                ANI_INCREASE_SOMETING = Properties.Resources.ANI_INCREASE_SOMETING;
                ANI_DECREASE_SOMETING = Properties.Resources.ANI_DECREASE_SOMETING;
            }
            else if (comboBoxLanguageSetting.Text.Equals("English"))
            {
                INT1 = loc_english.INT1;
                INT2 = loc_english.INT2;
                FLOAT1 = loc_english.FLOAT1;
                FLOAT2 = loc_english.FLOAT2;
                STRING1 = loc_english.STRING1;
                STRING2 = loc_english.STRING2;
                LOOP = loc_english.LOOP;
                COLOR = loc_english.COLOR;
                COLOR_RED = loc_english.COLOR_RED;
                COLOR_GREEN = loc_english.COLOR_GREEN;
                COLOR_BLUE = loc_english.COLOR_BLUE;

                // change ui's strings
                btnRun.Text = loc_english.UI_EXECUTE;

                UI_VARIABLE_NAME = loc_english.UI_VARIABLE_NAME;
                UI_VARIABLE_TYPE = loc_english.UI_VARIABLE_TYPE;
                UI_VARIABLE_VALUE = loc_english.UI_VARIABLE_VALUE;

                UI_MONITOR = loc_english.UI_MONITOR;
                UI_CODE = loc_english.UI_CODE;
                UI_CPU_INFO = loc_english.UI_CPU_INFO;
                UI_INSTRUCTION_NUMBER = loc_english.UI_INSTRUCTION_NUMBER;
                UI_TIME = loc_english.UI_TIME;
                UI_SPEED = loc_english.UI_SPEED;
                UI_COLOR_PALATTE = loc_english.UI_COLOR_PALATTE;
                UI_MEMORY_INFO = loc_english.UI_MEMORY_INFO;

                COMMAND_ASSIGN = loc_english.COMMAND_ASSIGN;
                COMMAND_PUTPIXEL = loc_english.COMMAND_PUTPIXEL;
                COMMAND_LOOPSTART = loc_english.COMMAND_LOOPSTART;
                COMMAND_LOOPEND = loc_english.COMMAND_LOOPEND;
                COMMAND_ADD = loc_english.COMMAND_ADD;
                COMMAND_SUB = loc_english.COMMAND_SUB;
                COMMAND_CLEAR = loc_english.COMMAND_CLEAR;
                COMMAND_DELAY = loc_english.COMMAND_DELAY;

                WARNING_CANT_USE_VARIABLE_VALUE = loc_english.WARNING_CANT_USE_VARIABLE_VALUE;
                WARNING_DOESNT_EXIST_COMMAND = loc_english.WARNING_DOESNT_EXIST_COMMAND;
                WARNING_CANT_ASSIGN_TO_SAME_VARIABLE = loc_english.WARNING_CANT_ASSIGN_TO_SAME_VARIABLE;
                WARNING_CANT_CONVERT = loc_english.WARNING_CANT_CONVERT;
                WARNING_DOESNT_EXIST = loc_english.WARNING_DOESNT_EXIST;

                UI_CODE_ANIMATION = loc_english.UI_CODE_ANIMATION;

                ANI_ASSIGN_SOMETING = loc_english.ANI_ASSIGN_SOMETING;
                ANI_OF_VALUE = loc_english.ANI_OF_VALUE;
                ANI_INCREASE_SOMETING = loc_english.ANI_INCREASE_SOMETING;
                ANI_DECREASE_SOMETING = loc_english.ANI_DECREASE_SOMETING;
            }

            lblMonitorName.Text = UI_MONITOR;
            lblCpuInfo.Text = UI_CPU_INFO;
            lblCode.Text = UI_CODE;
            lblCpuInfo.Text = UI_CPU_INFO;
            lblInstructionNumberName.Text = UI_INSTRUCTION_NUMBER;
            lblTimeName.Text = UI_TIME;
            lblCpuSpeedName.Text = UI_SPEED;
            lblColorPalatteName.Text = UI_COLOR_PALATTE;
            lblMemoryInfoName.Text = UI_MEMORY_INFO;
            lblColorRedName.Text = COLOR_RED;
            lblColorGreenName.Text = COLOR_GREEN;
            lblColorBlueName.Text = COLOR_BLUE;
            chkCodeAnimation.Text = UI_CODE_ANIMATION;


            MemoryList.Clear();
            MemoryList.Add(new MemoryVariable(INT1, MemoryVariable.VariableType.Int));
            MemoryList.Add(new MemoryVariable(INT2, MemoryVariable.VariableType.Int));

            MemoryList.Add(new MemoryVariable(FLOAT1, MemoryVariable.VariableType.Float));
            MemoryList.Add(new MemoryVariable(FLOAT2, MemoryVariable.VariableType.Float));

            MemoryList.Add(new MemoryVariable(STRING1, MemoryVariable.VariableType.String));
            MemoryList.Add(new MemoryVariable(STRING2, MemoryVariable.VariableType.String));

            MemoryList.Add(new MemoryVariable(LOOP, MemoryVariable.VariableType.Int));
            MemoryList.Add(new MemoryVariable(COLOR, MemoryVariable.VariableType.String));

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = UI_VARIABLE_NAME;
            dataGridView1.Columns[1].Name = UI_VARIABLE_TYPE;
            dataGridView1.Columns[2].Name = UI_VARIABLE_VALUE;
            
            RefreshMemoryVariables();
            RefreshInstructionIndex();
            
/*mov Int1 0
mov Int2 0
mov Color Red
putpixel
mov Int1 1
mov Int2 1
putpixel
mov Loop 10
loopstart
add Int1 1
add Int2 1
putpixel
loopend*/
            
        }
        
        private void virtualcomputer_Load(object sender, EventArgs e)
        {
            comboBoxLanguageSetting.Items.Add("한글");
            comboBoxLanguageSetting.Items.Add("English");
            comboBoxLanguageSetting.SelectedIndex = 0;

            LoadLanguageSetting();

            monitor.Size = new Size(200, 200);
            
            hScrollBarCpuSpeed.Value = 100;
        }

        private void ResetProgram()
        {
            InstructionIndex = 0;
            MaxInstructionIndex = 0;            
            CodeList.Clear();
                        
            bool ret = ReadProgram();
            if (!ret)
            {
                cpuClock.Enabled = false;
                return;
            }

            if (MaxInstructionIndex != 0)
            {
                cpuClock.Enabled = true;
            }
            else
            {
                cpuClock.Enabled = false;
            }
        }

        bool IsValidVariable(string val)
        {
            return GetVariable(val) != null;
        }

        private bool ReadProgram()
        {            
            string[] lines = richTextBox1.Lines;
            List<string> codes = new List<string>();
            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i].Length != 0)
                {
                    codes.Add(lines[i]);
                }
            }

            MaxInstructionIndex = Math.Max(codes.Count, 0);
            
            for (int i = 0; i < codes.Count; ++i)
            {
                // Parse the code
                string code = codes[i];                
                char[] separator = { ' ' };
                string[] codeElements = code.Split(separator);                

                if (codeElements[0].Equals(COMMAND_ASSIGN))
                {
                    Code newCode = new Code(i, Code.Type.ASSIGN);

                    if (codeElements[1].Equals(COLOR))
                    {
                        newCode.Target = COLOR;
                                                
                        // 색상값은 문자열 혹은 문자열 변수일 수 있다.
                        if (codeElements[2].Equals(STRING1) || codeElements[2].Equals(STRING2))
                        {
                            newCode.valueType = Code.ValueType.VARIABLE;
                            newCode.stringValue = codeElements[2];
                        }
                        else
                        {                            
                            newCode.valueType = Code.ValueType.CONSTANT;                            
                            newCode.stringValue = codeElements[2];
                        }
                    }
                    else if (codeElements[1].Equals(LOOP))
                    {
                        newCode.Target = LOOP;
                                                
                        // 상수 혹은 변수 값일 수 있다. 변수 값은 정수1, 정수2만 된다.
                        if (codeElements[2].Equals(INT1) || codeElements[2].Equals(INT2))
                        {
                            newCode.valueType = Code.ValueType.VARIABLE;
                            newCode.stringValue = codeElements[2];
                        }
                        else
                        {                       
                            int number = 0;
                             bool result = Int32.TryParse(codeElements[2], out number);
                             if (result)
                             {
                                 newCode.valueType = Code.ValueType.CONSTANT;
                                 newCode.intValue = number;
                             }
                             else
                             {
                                 MessageBox.Show(codeElements[2] + WARNING_CANT_CONVERT);
                                 return false;
                             }
                        }

                    }
                    else if ( codeElements[1].Equals(INT1) || codeElements[1].Equals(INT2) )
                    {
                        newCode.Target = codeElements[1];
                        
                        // 숫자인지 문자열인지 검사한다.
                        int number = 0;
                        bool result = Int32.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            // 숫자이므로 숫자 그대로 저장한다.
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.intValue = Convert.ToInt32(codeElements[2]);
                        }
                        else
                        {
                            // 문자라면 현재 변수와 같은 이름인지 체크한다.
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                if ( IsValidVariable(codeElements[2]) )
                                {
                                    newCode.valueType = Code.ValueType.VARIABLE;
                                    newCode.stringValue = codeElements[2];
                                }
                                else
                                {
                                    MessageBox.Show(codeElements[2] + WARNING_DOESNT_EXIST);
                                    return false;
                                }
                            }
                        }
                    }
                    else if ( codeElements[1].Equals(FLOAT1) || codeElements[1].Equals(FLOAT2) )
                    {
                        newCode.Target = codeElements[1];

                        float number = 0.0f;
                        bool result = float.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.floatValue = Convert.ToSingle(codeElements[2]);
                        }
                        else
                        {
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                if (IsValidVariable(codeElements[2]))
                                {
                                    newCode.valueType = Code.ValueType.VARIABLE;
                                    newCode.stringValue = codeElements[2];
                                }
                                else
                                {
                                    MessageBox.Show(codeElements[2] + WARNING_DOESNT_EXIST);
                                    return false;
                                }                            
                            }
                        }
                    }
                    else if (codeElements[1].Equals(STRING1) || codeElements[1].Equals(STRING2))
                    {
                        newCode.Target = codeElements[1];

                        // 문자열은 "으로 감싸져 있는지 검사하자.                        
                        newCode.stringValue = codeElements[2];
                    }
                    else
                    {
                        MessageBox.Show(codeElements[1] + WARNING_DOESNT_EXIST);
                        return false;
                    }

                    CodeList.Add(newCode);
                }
                else if (codeElements[0].Equals(COMMAND_PUTPIXEL))
                {
                    Code newCode = new Code(i, Code.Type.PUTPIXEL);
                    CodeList.Add(newCode);
                }
                else if (codeElements[0].Equals(COMMAND_LOOPSTART))
                {
                    Code newCode = new Code(i, Code.Type.LOOPSTART);
                    CodeList.Add(newCode);                    
                }
                else if (codeElements[0].Equals(COMMAND_LOOPEND))
                {
                    Code newCode = new Code(i, Code.Type.LOOPEND);
                    CodeList.Add(newCode);                  
                }
                else if (codeElements[0].Equals(COMMAND_ADD))
                {
                    Code newCode = new Code(i, Code.Type.ADD);
                    
                    if ( codeElements[1].Equals(INT1) || codeElements[1].Equals(INT2) )
                    {
                        newCode.Target = codeElements[1];
                        
                        // 숫자인지 문자열인지 검사한다.
                        int number = 0;
                        bool result = Int32.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            // 숫자이므로 숫자 그대로 저장한다.
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.intValue = Convert.ToInt32(codeElements[2]);
                        }
                        else
                        {
                            // 문자라면 현재 변수와 같은 이름인지 체크한다.
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                newCode.valueType = Code.ValueType.VARIABLE;
                                newCode.stringValue = codeElements[2];
                            }
                        }
                    }
                    else if ( codeElements[1].Equals(FLOAT1) || codeElements[1].Equals(FLOAT2) )
                    {
                        newCode.Target = codeElements[1];

                        float number = 0.0f;
                        bool result = float.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.floatValue = Convert.ToSingle(codeElements[2]);
                        }
                        else
                        {
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                newCode.valueType = Code.ValueType.VARIABLE;
                                newCode.stringValue = codeElements[2];
                            }
                        }
                    }
                    else if (codeElements[1].Equals(STRING1) || codeElements[1].Equals(STRING2))
                    {
                        newCode.Target = codeElements[1];
                        newCode.stringValue = codeElements[2];
                    }

                    CodeList.Add(newCode);
                }
                else if (codeElements[0].Equals(COMMAND_SUB))
                {
                    Code newCode = new Code(i, Code.Type.SUB);
                    
                    if (codeElements[1].Equals(INT1) || codeElements[1].Equals(INT2))
                    {
                        newCode.Target = codeElements[1];

                        // 숫자인지 문자열인지 검사한다.
                        int number = 0;
                        bool result = Int32.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            // 숫자이므로 숫자 그대로 저장한다.
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.intValue = Convert.ToInt32(codeElements[2]);
                        }
                        else
                        {
                            // 문자라면 현재 변수와 같은 이름인지 체크한다.
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                newCode.valueType = Code.ValueType.VARIABLE;
                                newCode.stringValue = codeElements[2];
                            }
                        }
                    }
                    else if (codeElements[1].Equals(FLOAT1) || codeElements[1].Equals(FLOAT2))
                    {
                        newCode.Target = codeElements[1];

                        float number = 0.0f;
                        bool result = float.TryParse(codeElements[2], out number);
                        if (result)
                        {
                            newCode.valueType = Code.ValueType.CONSTANT;
                            newCode.floatValue = Convert.ToSingle(codeElements[2]);
                        }
                        else
                        {
                            if (codeElements[1].Equals(codeElements[2]))
                            {
                                MessageBox.Show(codeElements[2] + WARNING_CANT_ASSIGN_TO_SAME_VARIABLE);
                                return false;
                            }
                            else
                            {
                                newCode.valueType = Code.ValueType.VARIABLE;
                                newCode.stringValue = codeElements[2];
                            }
                        }
                    }
                    else if (codeElements[1].Equals(STRING1) || codeElements[1].Equals(STRING2))
                    {
                        newCode.Target = codeElements[1];
                        newCode.stringValue = codeElements[2];
                    }

                    CodeList.Add(newCode);
                }
                else if (codeElements[0].Equals(COMMAND_CLEAR))
                {
                    Code newCode = new Code(i, Code.Type.CLEAR_MONITOR);
                    CodeList.Add(newCode);
                }
                else if ( codeElements[0].Equals(COMMAND_DELAY) )
                {
                    Code newCode = new Code(i, Code.Type.DELAY);

                    // 초당 지연
                    float number = 0.0f;
                    bool result = float.TryParse(codeElements[1], out number);
                    if ( result )
                    {
                        newCode.valueType = Code.ValueType.CONSTANT;
                        newCode.floatValue = number;
                    }
                    else
                    {
                        MessageBox.Show(WARNING_CANT_USE_VARIABLE_VALUE);
                        return false;
                    }
                                        
                    CodeList.Add(newCode);
                }
                else
                {
                    MessageBox.Show(code + WARNING_DOESNT_EXIST_COMMAND);
                    return false;
                }
            }

            return true;
        }

        private void RefreshMemoryVariables()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < MemoryList.Count; ++i)
            {
                string stringValue = "empty";
                if (MemoryList[i].type == MemoryVariable.VariableType.Int)
                {
                    stringValue = MemoryList[i].intValue.ToString();
                }
                else if (MemoryList[i].type == MemoryVariable.VariableType.Float)
                {
                    stringValue = MemoryList[i].floatValue.ToString();
                }
                else if (MemoryList[i].type == MemoryVariable.VariableType.String)
                {
                    stringValue = MemoryList[i].stringValue;
                }

                string[] data = { MemoryList[i].name, MemoryList[i].type.ToString(), stringValue };
                dataGridView1.Rows.Add(data);
            }
        }

        private void RefreshInstructionIndex()
        {
            lblInstructionNumberValue.Text = InstructionIndex.ToString();
        }

        private void cpuClock_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - StartTime;
            lblCpuTime.Text = span.TotalSeconds.ToString();
            
            if (EnableDelay)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan delaySpan = currentTime - DelayTime;
                if (delaySpan.Milliseconds > 0)
                {
                    EnableDelay = false;
                }
                return;
            }

            if (chkCodeAnimation.Checked)
            {
                if (!AnimStart)
                {
                    AnimExecute();
                }
            }
            else
            {
                Execute();
            }
        }

        private void RefreshMonitor()
        {
            monitor.Refresh();
        }

        MemoryVariable GetVariable(string name)
        {
            for (int i = 0; i < MemoryList.Count; ++i)
            {
                if (MemoryList[i].name.Equals(name))
                {
                    return MemoryList[i];
                }
            }
            return null;
        }

        private void AnimExecute()
        {
            // 명령어를 실행한다.
            Code code = CodeList[InstructionIndex];
            switch (code.CodeType)
            {
                case Code.Type.CLEAR_MONITOR:
                    EndOfAnimation();
                    break;

                case Code.Type.ASSIGN:
                    MemoryVariable target = GetVariable(code.Target);

                    AnimStart = true;
                    
                    // 해당 변수의 위치를 찾는다.
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[i].Cells[0];
                        string cellName = Convert.ToString(cell.Value);
                        if (cellName.Equals(target.name))
                        {
                            Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(2, i, false);

                            Point pt = dataGridView1.PointToScreen(cellRectangle.Location);
                            overWindow win = new overWindow();
                            win.VirtualComputer = this;

                            int charIndex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
                            Point richBoxPt = richTextBox1.PointToScreen(richTextBox1.GetPositionFromCharIndex(charIndex));
                            win.SetAnim(richBoxPt.X, richBoxPt.Y, pt.X, pt.Y, cellRectangle.Width, cellRectangle.Height);
                            
                            if (code.valueType == Code.ValueType.CONSTANT)
                            {
                                if (target.type == MemoryVariable.VariableType.Int)
                                {
                                    win.SetText(code.intValue.ToString() + ANI_ASSIGN_SOMETING);
                                }
                                else if (target.type == MemoryVariable.VariableType.Float)
                                {
                                    win.SetText(code.floatValue.ToString() + ANI_ASSIGN_SOMETING);
                                }
                                else if (target.type == MemoryVariable.VariableType.String)
                                {
                                    win.SetText(code.stringValue + ANI_ASSIGN_SOMETING);
                                }
                            }
                            else if (code.valueType == Code.ValueType.VARIABLE)
                            {
                                MemoryVariable sourceVariable = GetVariable(code.stringValue);                                
                                if (sourceVariable.type == MemoryVariable.VariableType.Int)
                                {
                                    win.SetText(sourceVariable.name + ANI_OF_VALUE + sourceVariable.intValue.ToString() + ANI_ASSIGN_SOMETING);
                                }
                                else if (sourceVariable.type == MemoryVariable.VariableType.Float)
                                {
                                    win.SetText(sourceVariable.name + ANI_OF_VALUE + sourceVariable.floatValue.ToString() + ANI_ASSIGN_SOMETING);
                                }
                                else if (sourceVariable.type == MemoryVariable.VariableType.String)
                                {
                                    win.SetText(sourceVariable.name + ANI_OF_VALUE + sourceVariable.stringValue + ANI_ASSIGN_SOMETING);
                                }
                            }
                            
                            win.Show();
                            break;
                        }
                    }
                    break;
                case Code.Type.PUTPIXEL:
                    AnimStart = true;
                    MemoryVariable x = GetVariable(INT1);
                    MemoryVariable y = GetVariable(INT2);
                    MemoryVariable color = GetVariable(COLOR);
                    if (y.intValue < 0 || y.intValue >= 10 ||
                            x.intValue < 0 || x.intValue >= 10)
                    {
                        // do nothing
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            DataGridViewCell cell = dataGridView1.Rows[i].Cells[0];
                            string cellName = Convert.ToString(cell.Value);
                            if (cellName.Equals(COLOR))
                            {
                                Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(2, i, false);

                                Point pt = dataGridView1.PointToScreen(cellRectangle.Location);
                                overWindow win = new overWindow();
                                win.VirtualComputer = this;

                                int charIndex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
                                Point richBoxPt = richTextBox1.PointToScreen(richTextBox1.GetPositionFromCharIndex(charIndex));
                                                                
                                Point pixelCoordInScreen = monitor.PointToScreen(new Point(x.intValue * 20, y.intValue * 20));

                                win.SetAnim(pt.X, pt.Y, pixelCoordInScreen.X, pixelCoordInScreen.Y, 20, 20);
                                win.SetText(color.stringValue);
                                win.Show();

                                break;
                            }
                        }
                    }                        

                    break;
                case Code.Type.LOOPSTART:
                    EndOfAnimation();                    
                    break;
                case Code.Type.LOOPEND:
                    EndOfAnimation();
                    break;
                case Code.Type.ADD:
                    MemoryVariable addTarget = GetVariable(code.Target);
                    
                    AnimStart = true;

                    // 해당 변수의 위치를 찾는다.
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[i].Cells[0];
                        string cellName = Convert.ToString(cell.Value);
                        if (cellName.Equals(addTarget.name))
                        {
                            Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(2, i, false);

                            Point pt = dataGridView1.PointToScreen(cellRectangle.Location);
                            overWindow win = new overWindow();
                            win.VirtualComputer = this;

                            int charIndex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
                            Point richBoxPt = richTextBox1.PointToScreen(richTextBox1.GetPositionFromCharIndex(charIndex));
                            win.SetAnim(richBoxPt.X, richBoxPt.Y, pt.X, pt.Y, cellRectangle.Width, cellRectangle.Height);

                            if (addTarget.type == MemoryVariable.VariableType.Int)
                            {
                                win.SetText(code.intValue.ToString() + ANI_INCREASE_SOMETING);
                            }
                            else if (addTarget.type == MemoryVariable.VariableType.Float)
                            {
                                win.SetText(code.floatValue.ToString() + ANI_INCREASE_SOMETING);
                            }
                            else if (addTarget.type == MemoryVariable.VariableType.String)
                            {
                                //win.SetText(code.stringValue + "을 대입");
                            }

                            win.Show();
                            break;
                        }
                    }
                    break;
                case Code.Type.SUB:
                    MemoryVariable subTarget = GetVariable(code.Target);
                    
                    AnimStart = true;

                    // 해당 변수의 위치를 찾는다.
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[i].Cells[0];
                        string cellName = Convert.ToString(cell.Value);
                        if (cellName.Equals(subTarget.name))
                        {
                            Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(2, i, false);

                            Point pt = dataGridView1.PointToScreen(cellRectangle.Location);
                            overWindow win = new overWindow();
                            win.VirtualComputer = this;

                            int charIndex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
                            Point richBoxPt = richTextBox1.PointToScreen(richTextBox1.GetPositionFromCharIndex(charIndex));
                            win.SetAnim(richBoxPt.X, richBoxPt.Y, pt.X, pt.Y, cellRectangle.Width, cellRectangle.Height);

                            if (subTarget.type == MemoryVariable.VariableType.Int)
                            {
                                win.SetText(code.intValue.ToString() + ANI_DECREASE_SOMETING);
                            }
                            else if (subTarget.type == MemoryVariable.VariableType.Float)
                            {
                                win.SetText(code.floatValue.ToString() + ANI_DECREASE_SOMETING);
                            }
                            else if (subTarget.type == MemoryVariable.VariableType.String)
                            {
                                //win.SetText(code.stringValue + "을 대입");
                            }
                            
                            win.Show();
                            break;
                        }
                    }
                    break;
                case Code.Type.DELAY:
                    EndOfAnimation();
                    break;
            }
        }
        
        private void Execute()
        {
            Code code = CodeList[InstructionIndex];
            switch (code.CodeType)
            {
                case Code.Type.CLEAR_MONITOR:
                    MonitorPixels = new Color[10, 10];
                    break;

                case  Code.Type.ASSIGN:
                    MemoryVariable target = GetVariable(code.Target);

                    if (code.valueType == Code.ValueType.CONSTANT)
                    {
                        if (target.type == MemoryVariable.VariableType.Int)
                        {
                            target.intValue = code.intValue;
                        }
                        else if (target.type == MemoryVariable.VariableType.Float)
                        {
                            target.floatValue = code.floatValue;
                        }
                        else if (target.type == MemoryVariable.VariableType.String)
                        {
                            target.stringValue = code.stringValue;
                        }
                    }
                    else if (code.valueType == Code.ValueType.VARIABLE)
                    {
                        MemoryVariable sourceVariable = GetVariable(code.stringValue);
                        
                        if (sourceVariable.type == MemoryVariable.VariableType.Int)
                        {                            
                            if (target.type == MemoryVariable.VariableType.Int)
                            {
                                target.intValue = sourceVariable.intValue;
                            }
                            else if (target.type == MemoryVariable.VariableType.Float)
                            {                    
                                // 업캐스팅이 일어난다. 10 -> 10.0f
                                target.floatValue = sourceVariable.intValue;
                            }
                        }
                        else if ( sourceVariable.type == MemoryVariable.VariableType.Float )
                        {
                            if ( target.type == MemoryVariable.VariableType.Int )
                            {
                                // 다운 캐스팅이 일어난다. 11.5f -> 11
                                target.intValue = (int)sourceVariable.floatValue;
                            }
                            else if (target.type == MemoryVariable.VariableType.Float)
                            {
                                target.floatValue = sourceVariable.floatValue;
                            }                            
                        }
                        else if (sourceVariable.type == MemoryVariable.VariableType.String)
                        {
                            if (target.type == MemoryVariable.VariableType.Int)
                            {
                                //MessageBox.Show("String을 Int로 변경할 수 없습니다.");                                
                                // string을 int로 변경할 수 있다면 변경한다.
                                //Int32.TryParse(sourceVariable.stringValue)                                
                            }
                            else if (target.type == MemoryVariable.VariableType.Float)
                            {
                                // string을 float으로 변경할 수 있다면 변경한다.
                                
                            }
                            else if (target.type == MemoryVariable.VariableType.String)
                            {
                                target.stringValue = sourceVariable.stringValue;
                            }
                        }
                    }

                    RefreshMemoryVariables();                   
                    break;
                case Code.Type.PUTPIXEL:
                    {
                        // 정수1는 x
                        // 정수2는 y
                        MemoryVariable x = GetVariable(INT1);
                        MemoryVariable y = GetVariable(INT2);
                        MemoryVariable color = GetVariable(COLOR);
                        if (y.intValue < 0 || y.intValue >= 10 ||
                             x.intValue < 0 || x.intValue >= 10)
                        {
                            // do nothing
                        }
                        else
                        {
                            if (color.stringValue.Equals(COLOR_RED) )
                            {
                                MonitorPixels[y.intValue, x.intValue] = Color.Red;
                            }
                            else if (color.stringValue.Equals(COLOR_GREEN) )
                            {
                                MonitorPixels[y.intValue, x.intValue] = Color.Green;
                            }
                            else if (color.stringValue.Equals(COLOR_BLUE)) 
                            {
                                MonitorPixels[y.intValue, x.intValue] = Color.Blue;
                            }
                        }                        
                    }
                    break;
                case Code.Type.LOOPSTART:
                    LoopStartIndex = code.CodeIndex;                                        
                    break;

                case Code.Type.LOOPEND:
                    MemoryVariable loopCount = GetVariable(LOOP);
                    loopCount.intValue--;
                    RefreshMemoryVariables();

                    if (loopCount.intValue > 0)
                    {
                        InstructionIndex = LoopStartIndex;
                        return;
                    }                    
                    break;

                case Code.Type.ADD:                    
                    MemoryVariable addTarget = GetVariable(code.Target);
                    if (addTarget.type == MemoryVariable.VariableType.Int)
                    {
                        addTarget.intValue += code.intValue;
                    }
                    else if (addTarget.type == MemoryVariable.VariableType.Float)
                    {
                        addTarget.floatValue = code.floatValue;
                    }
                    else if (addTarget.type == MemoryVariable.VariableType.String)
                    {
                        addTarget.stringValue = code.stringValue;
                    }
                    RefreshMemoryVariables();                    
                    break;                 
                case Code.Type.SUB:
                    MemoryVariable subTarget = GetVariable(code.Target);
                    if (subTarget.type == MemoryVariable.VariableType.Int)
                    {
                        subTarget.intValue -= code.intValue;
                    }
                    else if (subTarget.type == MemoryVariable.VariableType.Float)
                    {
                        subTarget.floatValue -= code.floatValue;
                    }
                    else if (subTarget.type == MemoryVariable.VariableType.String)
                    {
                        subTarget.stringValue = code.stringValue;
                    }
                    RefreshMemoryVariables();                    
                    break;
                case Code.Type.DELAY:
                    if (code.valueType == Code.ValueType.CONSTANT)
                    {   
                        DelayTime = DateTime.Now.AddSeconds(code.floatValue);
                        EnableDelay = true;
                    }
                    break;
            }

            RefreshMonitor();
            
            int firstcharindex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
            int currentline = InstructionIndex;
            string currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);
            richTextBox1.SelectionBackColor = Color.Yellow;
                        
            InstructionIndex++;
            RefreshInstructionIndex();

            if (InstructionIndex >= MaxInstructionIndex)
            {
                cpuClock.Enabled = false;
                return;
            }

            firstcharindex = richTextBox1.GetFirstCharIndexFromLine(InstructionIndex);
            currentline = InstructionIndex;
            currentlinetext = richTextBox1.Lines[currentline];
            richTextBox1.Select(firstcharindex, currentlinetext.Length);
            richTextBox1.SelectionBackColor = Color.White;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ResetProgram();
            StartTime = DateTime.Now;
        }

        public void EndOfAnimation()
        {
            AnimStart = false;
            Execute();                 
        }

        private void hScrollBarCpuSpeed_ValueChanged(object sender, EventArgs e)
        {
            cpuClock.Interval = hScrollBarCpuSpeed.Value;
            lblCpuSpeed.Text = hScrollBarCpuSpeed.Value.ToString();
        }

        private void comboBoxLanguageSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxLanguageSetting_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLanguageSetting();
        }
    }
}
