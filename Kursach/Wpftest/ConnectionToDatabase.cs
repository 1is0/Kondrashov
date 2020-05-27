using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.ObjectModel;

namespace Wpftest
{

    class ConnectionToDatabase
    {
        public int CurrentTestId { get; set; }
        public ObservableCollection<string> splitReadView = new ObservableCollection<string>();
        public ArrayList ConnectionToTestNumbers()
        {

            string connStr = "server=localhost;user=root;database=kursach;password=0000;";

            MySqlConnection connect = new MySqlConnection(connStr);

            connect.Open();

            string sql = "SELECT id,name FROM testnumbers";

            MySqlCommand comm = new MySqlCommand(sql, connect);

            MySqlDataReader read = comm.ExecuteReader();

            ArrayList readInt = new ArrayList();

            while (read.Read())
            {
                readInt.Add(int.Parse(read[0].ToString()));
            }

            connect.Close();

            return readInt;
        }

        public ArrayList ConnectionToTestTasks(int a)
        {
            string connStr = "server=localhost;user=root;database=kursach;password=0000;";

            MySqlConnection connect = new MySqlConnection(connStr);

            string sql2 = "SELECT id,task,correctanswerid FROM testtasks WHERE testid=" + a.ToString();

            connect.Open();

            MySqlCommand command = new MySqlCommand(sql2, connect);
            MySqlDataReader reader = command.ExecuteReader();

            ArrayList testTask = new ArrayList();

            while (reader.Read())
            {
                CurrentTestId++;
                Tasks temp = new Tasks(int.Parse(reader[0].ToString()),
                                       reader[1].ToString(),
                                       CurrentTestId,
                                       int.Parse(reader[2].ToString()));
                testTask.Add(temp);

            }

            connect.Close();

            return testTask;
        }

        public ArrayList ConnectionToTestAnswers(int a, int id)
        {
            string connStr = "server=localhost;user=root;database=kursach;password=0000;";

            MySqlConnection connect = new MySqlConnection(connStr);

            string sql2 = "SELECT id,answers FROM testtasks WHERE testid=" + a.ToString() +
                " AND id=" + id.ToString();

            connect.Open();

            MySqlCommand command = new MySqlCommand(sql2, connect);
            MySqlDataReader readview = command.ExecuteReader();

            ArrayList testAnswer = new ArrayList();

            while (readview.Read())
            {

                string readerStr = readview[1].ToString();
                string[] str = readerStr.Split(';');
                int i = 0;
                string sum = "";

                foreach (string s in str)
                {
                    Answers m = new Answers(i, sum + " " + s);
                    testAnswer.Add(m);
                    i++;
                }

            }

            connect.Close();

            return testAnswer;
        }
    }
}