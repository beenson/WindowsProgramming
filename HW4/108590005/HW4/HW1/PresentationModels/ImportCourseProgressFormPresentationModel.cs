using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework1
{
    public class ImportCourseProgressFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event CrawlerDoneEventHandler _crawlerDone;
        public delegate void CrawlerDoneEventHandler();

        static string IMPORTING_COURSE = "正在匯入課程...";
        static string PERCENT = "%";
        readonly string[] CODES = { "2701", "2676", "2550", "2433", "2314"};

        Model _model;

        public ImportCourseProgressFormPresentationModel(Model model)
        {
            this._model = model;
        }

        // 取得 Model
        public Model GetModel()
        {
            return _model;
        }

        // 開始爬取資工系課程
        public async void StartCrawler()
        {
            _precentage = 0;
            for (int i = 0; i < CODES.Length; i++)
            {
                _model.CourseCrawler(CODES[i]);
                _precentage = (i + 1) * 100 / CODES.Length;
                NotifyPropertyChanged(nameof(Percentage));
                NotifyPropertyChanged(nameof(ProgressInfo));
                if (i == CODES.Length - 1)
                    _crawlerDone();
                await Task.Delay(500);
            }
        }

        // 通知 Property
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _precentage;
        public int Percentage 
        {
            get
            {
                return _precentage;
            }
        }

        public string ProgressInfo
        {
            get
            {
                return IMPORTING_COURSE + _precentage + PERCENT;
            }
        }
    }
}
