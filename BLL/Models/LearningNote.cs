using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class LearningNote
    {
        /// <summary>
        /// ����ID
        /// </summary>
        public int NotesID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string NotesTitle { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string NotesAuthor { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public Nullable<int> NotesType { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime CreateDate { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public Nullable<System.DateTime> ModifyDate { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string NotesContents { get; set; }
        /// <summary>
        /// �Ķ���
        /// </summary>
        public Nullable<int> NotesReadNum { get; set; }
        /// <summary>
        /// ����ID��
        /// </summary>
        public string CommentID { get; set; }
    }
}
