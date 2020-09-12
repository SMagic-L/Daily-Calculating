using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace 笔算天天练
{
    [Activity(Label = "笔算天天练  By SMagic", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity :AppCompatActivity
    
    {
        protected override void OnCreate(Bundle savedInstanceState)
        
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get UI controls from the loaded layout
            RadioGroup radioGroup1 = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            RadioButton radioArith = FindViewById<RadioButton>(Resource.Id.radioArith);
            RadioButton radioEclipse = FindViewById<RadioButton>(Resource.Id.radioEclipse );
            RadioButton radioNormalVector = FindViewById<RadioButton>(Resource.Id.radioNormalVector );
            RadioButton radioImaginaryDivide = FindViewById<RadioButton>(Resource.Id.radioImaginaryDivide );
            TextView textViewArithTip = FindViewById<TextView>(Resource.Id.textViewArithTip);
            EditText editTextArithArgu = FindViewById<EditText>(Resource.Id.editTextArithArgu);
            Button buttonShowQuestion = FindViewById<Button>(Resource.Id.buttonShowQuestion);
            Button buttonShowAnswer = FindViewById<Button>(Resource.Id.buttonShowAnswer);
            TextView textViewTime = FindViewById<TextView>(Resource.Id.textViewTime);
            TextView textViewQuestion = FindViewById<TextView>(Resource.Id.textViewQuestion);
            TextView textViewAnswer = FindViewById<TextView>(Resource.Id.textViewAnswer);

            //Add Event Handler
            radioArith.Click += RadioButtonClick;
            radioEclipse.Click += RadioButtonClick;
            radioNormalVector.Click += RadioButtonClick;
            radioImaginaryDivide.Click += RadioButtonClick;
                       
            //Code Area
            buttonShowQuestion.Click += (sender, e) =>
            {
                 
                textViewAnswer.Text = "";
                textViewTime.Text = "本次用时";
                //TODO 将各个case提取为函数
                try
                {
                    //Declaration 
                    QA myQA;

                    //start timeing
                    StartTime = System.DateTime.Now;

                    //select mode
                    switch (RadioButtonIndex)
                    {
                        case "四则运算":
                            //Get argument
                            string[] arithArgu = editTextArithArgu.Text.Split(" ");
                            myQA = GetArithQA(editTextArithArgu.Text);
                            break;
                        case "椭圆联立直线":
                            myQA = GetEclipseQA();
                            break;
                        case "已知三点求法向量":
                            myQA = GetNormalVectorQA();
                            break;
                        case "虚数除法":
                            myQA = GetImaginaryDivideQA();
                            
                            
                            break;
                        default:
                            myQA = new QA("","");
                            break;
                     }
                    textViewQuestion.Text = myQA.Q;
                    Answer = myQA.A;

                }
                 catch(System.Exception ex)
                 {
                     textViewQuestion.Text = ex.Message;
                    textViewAnswer.Text = "";
                 }
             };

            buttonShowAnswer.Click += (sender, e) =>
            {
                System.TimeSpan t = System.DateTime.Now - StartTime;
                textViewAnswer.Text = "======答案======\n" + Answer;
                if (textViewTime.Text == "本次用时")
                    textViewTime.Text = "本次用时：" + t.Seconds + " s";
           
            };
            
        }

        

        public string RadioButtonIndex { get; set; } = "四则运算";  //radiobutton 的选中项，初始为四则运算
        private void RadioButtonClick(object sender, System.EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            RadioButtonIndex = rb.Text;

            //
            TextView textViewQuestion = FindViewById<TextView>(Resource.Id.textViewQuestion);
            TextView textViewAnswer = FindViewById<TextView>(Resource.Id.textViewAnswer);
            textViewQuestion.Text = ""; textViewAnswer.Text = "";

            //
            TextView textViewArithTip = FindViewById<TextView>(Resource.Id.textViewArithTip);
            if (rb.Text == "四则运算")
                textViewArithTip.Text = ARITHTIP;
            else
                textViewArithTip.Text = "";
        }
        public string Answer { get; set; } = "";
        const string ARITHTIP = "四则运算时，在下方输入算数类型与运算数的位数，用空格分隔，例如：3 3 2表示3位数乘2位数。加法与乘法的两个位数指定操作数的位数，减法与除法的第一个位数指定答案的位数，位数不能超过9。";
        public System.DateTime StartTime { get; set; } 
        private System.Random ran = new System.Random() ;
        public QA GetArithQA(string arithArgu)
        {
            //Declaration
            int numA = 0, numB = 0, numAnswer = 0;
            string questionString = "";
            int arithType; // 输入的运算类型
            int[] numberLength = new int[2];
            QA result ;

            string[] splitArithArgu = arithArgu.Split(" ");
            if (!int.TryParse(splitArithArgu[0].ToString(), out arithType))
            {
                throw new System.Exception("运算类型输入错误");
                
            };
            if (!int.TryParse(splitArithArgu[1].ToString(), out numberLength[0]))
            {
                throw new System.Exception("数字位数输入错误");
            };
            if (!int.TryParse(splitArithArgu[2].ToString(), out numberLength[1]))
            {
                throw new System.Exception("数字位数输入错误");
            };

            //another switch
            switch (arithType)
            {
                case 1:
                    {
                        numA = ran.Next((int)System.Math.Pow(10, (numberLength[0] - 1)), (int)System.Math.Pow(10, numberLength[0]) - 1);
                        numB = ran.Next((int)System.Math.Pow(10, (numberLength[1] - 1)), (int)System.Math.Pow(10, numberLength[1]) - 1);
                        numAnswer = numA + numB;
                        questionString = numA.ToString() + " + " + numB.ToString();
                        break;
                    }

                case 2:
                    {
                        numAnswer = ran.Next((int)System.Math.Pow(10, (numberLength[0] - 1)), (int)System.Math.Pow(10, numberLength[0]) - 1);
                        numB = ran.Next((int)System.Math.Pow(10, (numberLength[1] - 1)), (int)System.Math.Pow(10, numberLength[1]) - 1);
                        numA = numB + numAnswer;
                        questionString = numA.ToString() + " - " + numB.ToString();
                        break;
                    }

                case 3:
                    {
                        numA = ran.Next((int)System.Math.Pow(10, (numberLength[0] - 1)), (int)System.Math.Pow(10, numberLength[0]) - 1);
                        numB = ran.Next((int)System.Math.Pow(10, (numberLength[1] - 1)), (int)System.Math.Pow(10, numberLength[1]) - 1);
                        numAnswer = numA * numB;
                        questionString = numA.ToString() + " * " + numB.ToString();
                        break;
                    }

                case 4:
                    {
                        numAnswer = ran.Next((int)System.Math.Pow(10, (numberLength[0] - 1)), (int)System.Math.Pow(10, numberLength[0]) - 1);
                        numB = ran.Next((int)System.Math.Pow(10, (numberLength[1] - 1)), (int)System.Math.Pow(10, numberLength[1]) - 1);
                        numA = numAnswer * numB;
                        questionString = numA.ToString() + " / " + numB.ToString();
                        break;
                    }


            }
            result.Q = questionString;
            result.A = numAnswer.ToString();
            return result;
        }
        public QA GetEclipseQA()
        {
            //Declaration
            int a = 0, b = 0, t = 0;
            string fA = "";   // 表示a2k2 + b2 的字符串
            QA result;
            if (ran.Next(0, 2) >= 1)
            {
                a = ran.Next(1, 5); b = ran.Next(1, 5); t = ran.Next(-b, b);
                fA = "(" + (a * a) + "k^2 + " + (b * b) + ")";
                result.Q = "y = kx + " + t.ToString() + "\nx^2 / " + (a * a).ToString() + " + y^2 / " + (b * b).ToString() + " = 1";
                result.A = fA + "x^2 + " + (2 * t * a * a).ToString() + "kx + " + (a * a * (t * t - b * b)).ToString() + " = 0"
                 + "\nΔ = " + (4 * a * a * b * b) + "(" + (a * a) + "k^2 + " + (-t * t + b * b) + ")"
                  + "\nx1 + x2 = " + (-2 * a * a * t) + "k / " + fA
                   + "\nx1 * x2 = " + (a * a * (t * t - b * b)).ToString() + " / " + fA
                    + "\ny1 + y2 = " + (2 * b * b * t) + " / " + fA
                     + "\ny1 * y2 = " + (b * b) + "(" + (t * t).ToString() + " + " + (-1 * a * a) + "k^2) / " + fA;
            }
            else
            {
                a = ran.Next(1, 5); b = ran.Next(1, 5); t = ran.Next(-a, a);
                fA = "(" + (a * a) + "m^2 + " + (b * b) + ")";
                result.Q = "x = my + " + t.ToString() + "\ny^2 / " + (a * a).ToString() + " + x^2 / " + (b * b).ToString() + " = 1";
                result.A = fA + "y^2 + " + (2 * t * a * a).ToString() + "my + " + (a * a * (t * t - b * b)).ToString() + " = 0"
                 + "\nΔ = " + (4 * a * a * b * b) + "(" + (a * a) + "m^2 + " + (-t * t + b * b) + ")"
                  + "\ny1 + y2 = " + (-2 * a * a * t) + "m / " + fA
                   + "\ny1 * y2 = " + (a * a * (t * t - b * b)).ToString() + " / " + fA
                    + "\nx1 + x2 = " + (2 * b * b * t) + " / " + fA
                     + "\nx1 * x2 = " + (b * b) + "(" + (t * t).ToString() + " + " + (-1 * a * a) + "m^2) / " + fA;

            }
            return result;
        }
        public QA GetNormalVectorQA()
        {
            //Declaration
            int[] A = new int[3], B = new int[3], C = new int[3];
            int i = 0;
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0, z1 = 0, z2 = 0;
            QA result;

            for (i = 0; i <= 2; i++)
            {
                A[i] = ran.Next(1, 6);
                B[i] = ran.Next(1, 6);
                C[i] = ran.Next(1, 6);
            }
            for (i = 0; i <= 2; i++)
            {
                A[i] = ran.Next(1, 6);
                B[i] = ran.Next(1, 6);
                C[i] = ran.Next(1, 6);
            }
            x1 = B[0] - A[0]; y1 = B[1] - A[1]; z1 = B[2] - A[2];
            x2 = C[0] - A[0]; y2 = C[1] - A[1]; z2 = C[2] - A[2];
            result.Q = "A(" + A[0] + "," + A[1] + "," + A[2] + ")  " + "B(" + B[0] + "," + B[1] + "," + B[2] + ")  " + "C(" + C[0] + "," + C[1] + "," + C[2] + ")  ";
            result.A = "AB = (" + x1 + "," + y1 + "," + z1 + ")"
            + "\nAC = (" + x2 + "," + y2 + "," + z2 + ")"
             + "\nCB = (" + (x1 - x1) + "," + (y1 - y2) + "," + (z1 - z2) + ")"
              + "\nn = (" + (y1 * z2 - y2 * z1) + "," + (z1 * x2 - z2 * x1) + "," + (x1 * y2 - x2 * y1) + ")";
            return result;


        }
        public QA GetImaginaryDivideQA()
        {
            System.Numerics.Complex z1 = new System.Numerics.Complex(ran.Next (1,5),ran.Next(1,5)), z2 = new System.Numerics.Complex(ran.Next(1,5),ran.Next(1,5));
            QA result;
            result.Q = z1.ToString() + "/" + z2.ToString();
            result.A = (z1 / z2).ToString();
            return result;
        }
        




}
    }
    public struct QA
    {
        public string Q ;
        public string A ;
    
    public QA(string v1, string v2) : this()
    {
        Q = v1;
        A = v2;
    }
}


