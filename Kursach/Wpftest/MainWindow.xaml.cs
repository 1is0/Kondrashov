using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Wpftest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Коллекция для ComboBox
        public ObservableCollection<string> list = new ObservableCollection<string>();
        //Коллекция для вывода заданий теста в TaskList
        public ObservableCollection<Tasks> listOfTasks { get; set; }
        //Коллекция для вывода ответов теста в AnswerList
        public ObservableCollection<Answers> listOfAnswers { get; set; }

        bool isRight = false;

        ConnectionToDatabase model = new ConnectionToDatabase();


        DispatcherTimer timer;
        DispatcherTimer timerOne;
        TimeSpan timeForTest = new TimeSpan(0, 10, 0);

        private int TestIdFromComboBox;


        public MainWindow()
        {
            InitializeComponent();
            TestIdFromComboBox = 1;
            ArrayList source = model.ConnectionToTestNumbers();

            foreach (int i in source)
            {
                list.Add(i.ToString());
            }

            ComboMain.ItemsSource = list;
            ComboMain.SelectedIndex = 0;
            TaskList.FontSize = 12;
            AnswerList.FontSize = 12;
            Button1.IsEnabled = true;
            Button2.IsEnabled = false;
            MessageBox.Show("Вас приветствует программа для решения тестов по языку программирования C#!" + "\n" +
                            "Для того, чтобы начать тест нажмите кнопку <Начать тест>." + "\n" +
                            "Вам будут предоставлены 10 вопросов с 4 вариантами ответов и 10 минут для их решения." + "\n" +
                            "После того, как вы выполнили задания, нажмите кнопку <Завершить тест> и вам будут предоставлены ваши результаты." + "\n" +
                            "Желаем удачи!");
        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            model.CurrentTestId = 0;
            Button1.IsEnabled = false;
            Button2.IsEnabled = true;
            ComboMain.IsEnabled = false;
            isRight = false;

            var selectedItem = ComboMain.SelectedItem;
            if (selectedItem != null)
            {
                try
                {
                    string selectedItemStr = selectedItem.ToString();
                    TestIdFromComboBox = int.Parse(selectedItemStr);
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ArrayList task = model.ConnectionToTestTasks(TestIdFromComboBox);

            listOfTasks = new ObservableCollection<Tasks>();
            foreach (Object obj in task)
            {
                listOfTasks.Add((Tasks)obj);
            }
            TaskList.ItemsSource = listOfTasks;

            timeForTest = TimeSpan.FromMinutes(10);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timeForTest = timeForTest.Subtract(TimeSpan.FromSeconds(1));
            lblTime.Content = timeForTest.ToString();
            TimeSpan check = new TimeSpan(0, 0, 0);
            if(timeForTest == check)
            {
                Button2_Click(sender,null);
            }
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ComboMain.SelectedItem;
            if (selectedItem != null)
            {
                try
                {
                    string selectedItemStr = selectedItem.ToString();
                    TestIdFromComboBox = int.Parse(selectedItemStr);
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Создание объеста класса Tasks
            Tasks task = (Tasks)TaskList.SelectedItem;
            if (task != null)
            {
                ArrayList answer = model.ConnectionToTestAnswers(TestIdFromComboBox, task.Id);
                listOfAnswers = new ObservableCollection<Answers>();
                foreach (Object obj in answer)
                {
                    listOfAnswers.Add((Answers)obj);

                }

                AnswerList.ItemsSource = listOfAnswers;

                if (task.UserAnswer != -1 || isRight==true)
                {
                    timerOne = new DispatcherTimer();
                    timerOne.Interval = TimeSpan.FromMilliseconds(10);
                    timerOne.Tick += timerOne_Tick;
                    timerOne.Start();
                }
            }
        }

        void timerOne_Tick(object sender, EventArgs e)
        {
            Tasks task = (Tasks)TaskList.SelectedItem;
            if (task != null)
            {
                if (task.UserAnswer != -1)
                {
                    ListBoxItem lbi2 = (ListBoxItem)AnswerList.ItemContainerGenerator.ContainerFromIndex(task.UserAnswer - 1);
                    lbi2.Foreground = Brushes.Blue;
                }
            }
            if(isRight == true)
            {                
                ListBoxItem lbi2 = (ListBoxItem)AnswerList.ItemContainerGenerator.ContainerFromIndex(task.CorrectAnswer - 1);
                lbi2.Foreground = Brushes.Green;
            }
            timerOne.Stop();
        }

        private void AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Создание объекта класса Answers
            Answers answer = (Answers)AnswerList.SelectedItem;
            Tasks task = (Tasks)TaskList.SelectedItem;

            if (answer != null)
            {
                int answerId = answer.Id + 1;
                if (task.UserAnswer != -1)
                {
                    ListBoxItem lbp = (ListBoxItem)AnswerList.ItemContainerGenerator.ContainerFromIndex(task.UserAnswer - 1);
                    lbp.Foreground = Brushes.Black;
                }
                task.UserAnswer = answerId;

                ListBoxItem lbi = (ListBoxItem)TaskList.ItemContainerGenerator.ContainerFromIndex(TaskList.SelectedIndex);
                lbi.Foreground = Brushes.Blue;

                ListBoxItem lbi2 = (ListBoxItem)AnswerList.ItemContainerGenerator.ContainerFromIndex(AnswerList.SelectedIndex);
                lbi2.Foreground = Brushes.Blue;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Button2.IsEnabled = false;
            Button1.IsEnabled = true;
            ComboMain.IsEnabled = true;
            int i = 0;
            int tempAnswer = 0;
            int nonAnswer = 0;
            isRight = true;
            foreach (Object obj in listOfTasks)
            {
                Tasks task = (Tasks)obj;
                ListBoxItem lbi = (ListBoxItem)TaskList.ItemContainerGenerator.ContainerFromIndex(i);
                if (task.CorrectAnswer == task.UserAnswer)
                {
                    lbi.Foreground = Brushes.Green;
                    tempAnswer++;
                }
                else
                {
                    lbi.Foreground = Brushes.Red;
                    nonAnswer++;
                }
                i++;
            }
            if (tempAnswer >= 6 && tempAnswer <= 10)
            {
                MessageBox.Show("Ваш результат составил: "
                                 + tempAnswer.ToString() + "\n"
                                 + "Вы не ответили на "
                                 + nonAnswer.ToString() + " вопроса(ов)" + "\n"
                                 + "Поздравляем! Вы сдали тест!");

            }
            else
            {
                MessageBox.Show("Ваш результат составил: "
                                 + tempAnswer.ToString() + "\n"
                                 + "Вы не ответили на "
                                 + nonAnswer.ToString() + " вопроса(ов)" + "\n"
                                 + "К сожалению, в этот раз тест сдать не получилось.");
            }
        }
    }
}
