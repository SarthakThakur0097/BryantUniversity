using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class MajorPreRequisite
    {
        public MajorPreRequisite(){ }

        public MajorPreRequisite(int? preReqId, int courseId)
        {
            PreReqId = preReqId;
            CourseId = courseId;
        }

        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int? PreReqId { get; set; }
        public Course PreReq { get; set; }

    }
}