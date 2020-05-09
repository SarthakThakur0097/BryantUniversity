using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public int? PreReqId { get; set; }
        [ForeignKey("PreReqId")]
        public Course PreReq { get; set; }

    }
}