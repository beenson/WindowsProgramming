using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace homework1
{
    public class Model
    {
        private List<string> _headers = new List<string>();
        private List<Course> _courses = new List<Course>();

        public Model()
        {
            const string LINK = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            const string X_PATH = "//body/table";
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(LINK);

            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(X_PATH);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);
            foreach (var node in nodeTableRow[0].ChildNodes)
            {
                _headers.Add(node.InnerText.Trim());
            }
            // 移除 table header
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>小計
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);

            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                // 移除 #text
                nodeTableDatas.RemoveAt(0);

                _courses.Add(new Course(nodeTableDatas));
            }
        }

        // 取得課表header
        public List<string> GetHeaders()
        {
            return _headers;
        }

        // 取得course
        public List<Course> GetCourses()
        {
            return _courses;
        }

        // 是否能被確認送出
        public bool EnableConfirm(List<bool> selectState)
        {
            return selectState.Any(a => a);
        }
    }
}
