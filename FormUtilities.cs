using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuneAssignments
{
    public class FormUtilities
    {
        // This class will contain methods that are used by multiple forms to reduce code duplication and improve maintainability of the codebase as a whole.

        // All members must be static so that they can be called from other classes without instantiating an object of this class

        public static void ClearRichTextBox(RichTextBox richTextBox)
        {

            richTextBox.Clear();

        }

        public static void ClearDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static void ClearCheckedListBox(CheckedListBox checkedListBox)
        {

            checkedListBox.Items.Clear();

        }

        public static void WriteToLog(string data)
        {

            // This method will be used to log data to the main log file

            // Create a new instance of the StreamWriter class
            System.IO.StreamWriter sw = new System.IO.StreamWriter(GlobalVariables.MainLogFile, true);

            // Write the data to the log file
            sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {data}");

            // Close the StreamWriter instance
            sw.Close();

        }


    }
}
