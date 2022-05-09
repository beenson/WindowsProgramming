using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public class StartUpFormPresentationModel
    {
        private Model _model;

        public StartUpFormPresentationModel(Model model)
        {
            this._model = model;
        }

        // 創建 CourseSelectingFormPresentationModel
        public CourseSelectingFormPresentationModel GetCourseSelectingPresentationModel()
        {
            return new CourseSelectingFormPresentationModel(_model);
        }
    }
}
