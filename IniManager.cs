using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace FileIOManager
{
    public class IniManager
    {
        private string _path;


        #region Constructors
        public IniManager()
        {
            _path = Path.Combine(Application.Path, "Ini");
            _SetLogPath();
        }
        #endregion

        #region Method
        /// <summary>
        /// 파일 경로 생성
        /// </summary>
        private void _SetLogPath()
        {

            string name = "Ini";

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            name = "GridCellWidth.ini";

            _path = Path.Combine(_path, name);
        }

        [DllImport("Kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("Kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //ini Wirte
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _path);
        }
        //ini Read
        public string Read(string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, sb.Capacity, _path);
            return sb.ToString();
        }




        #endregion
    }
}
