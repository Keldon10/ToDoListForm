using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListForm
{
    class TextFileUtil
    {
        public static void writeToFile(List<ToDo> items)
        {
            try
            {
                using(StreamWriter outputFile = new StreamWriter("C:\\Users\\Keldo\\source\\repos\\ToDoListForm\\Todo.txt"))
                {
                    foreach (ToDo item in items)
                        outputFile.WriteLine(item.Description + "#" +
                            item.Date + "#" + item.Priority);
                }             
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void writeToFile(ToDo item)
        {
            try
            {
                using(StreamWriter outputFile = new StreamWriter("C:\\Users\\Keldo\\source\\repos\\ToDoListForm\\Todo.txt", true))
                {
                    outputFile.WriteLine(item.Description + "#" +
                        item.Date + "#" + item.Priority);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<ToDo> readFromFile()
        {
            List<ToDo> tempList = new List<ToDo>();
            try
            {
                using(StreamReader reader = new StreamReader("C:\\Users\\Keldo\\source\\repos\\ToDoListForm\\Todo.txt"))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] lineParts = line.Split('#');

                        string category = lineParts[0];
                        string desc = lineParts[1];
                        string date = lineParts[2];

                        string[] dateParts = date.Split('/');
                        int year = Convert.ToInt32(dateParts[0]);
                        int month = Convert.ToInt32(dateParts[1]);
                        int day = Convert.ToInt32(dateParts[2].Substring(0, 2));

                        DateTime dates = new DateTime(year, month, day);

                        string priority = lineParts[3];
                        ToDo.Levels level;
                        switch (priority)
                        {
                            case "Not Important":
                                level = ToDo.Levels.NotImportant;
                                break;
                            case "Important":
                                level = ToDo.Levels.Important;
                                break;
                            default:
                                level = ToDo.Levels.Urgent;
                                break;
                        }
                        ToDo t = new ToDo(category, desc, dates, level);
                        tempList.Add(t);
                    }
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return (tempList);
        }
    }
}
