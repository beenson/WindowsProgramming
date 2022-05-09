using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CourseInfoDto> courseInfo = GetCourseInfo();
        }

        private static List<CourseInfoDto> GetCourseInfo()
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument doc = webClient.Load("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433");
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();

            HtmlNode nodeTable = doc.DocumentNode.SelectSingleNode("//body/table");
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);
            // 移除 table header
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>小計
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);

            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                // 移除 #text
                nodeTableDatas.RemoveAt(0);

                courseInfoDtos.Add(
                    new CourseInfoDto(
                        nodeTableDatas[0].InnerText.Trim(),     // number
                        nodeTableDatas[1].InnerText.Trim(),     // name
                        nodeTableDatas[2].InnerText.Trim(),     // stage
                        nodeTableDatas[3].InnerText.Trim(),     // credit
                        nodeTableDatas[4].InnerText.Trim(),     // hour
                        nodeTableDatas[5].InnerText.Trim(),     // required/elective
                        nodeTableDatas[6].InnerText.Trim(),     // teacher
                        new List<string>                        //classTime
                        {
                            nodeTableDatas[7].InnerText.Trim(),
                            nodeTableDatas[8].InnerText.Trim(),
                            nodeTableDatas[9].InnerText.Trim(),
                            nodeTableDatas[10].InnerText.Trim(),
                            nodeTableDatas[11].InnerText.Trim(),
                            nodeTableDatas[12].InnerText.Trim(),
                            nodeTableDatas[13].InnerText.Trim()
                        },
                        nodeTableDatas[14].InnerText.Trim(),    // classroom
                        nodeTableDatas[15].InnerText.Trim(),    // numberOfStudent
                        nodeTableDatas[16].InnerText.Trim(),    // numberOfDropStudent
                        nodeTableDatas[17].InnerText.Trim(),    // TA
                        nodeTableDatas[18].InnerText.Trim(),    // language
                        nodeTableDatas[19].InnerText.Trim(),    // syllabus
                        nodeTableDatas[20].InnerText.Trim(),    // note
                        nodeTableDatas[21].InnerText.Trim(),    // audit
                        nodeTableDatas[22].InnerText.Trim()));  // experiment
            }

            return courseInfoDtos;
        }
    }
}
