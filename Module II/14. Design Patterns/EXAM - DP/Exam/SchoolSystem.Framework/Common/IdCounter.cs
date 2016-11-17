namespace SchoolSystem.Framework.Common
{
    public class IdCounter
    {
        private const int StartingStudentId = 0;

        private const int StartingTeacherId = 0;

        private static volatile IdCounter instance;

        private static object syncLock = new object();

        private static int studentCounter = StartingStudentId;

        private static int teacherCounter = StartingTeacherId;

        private IdCounter()
        {
        }

        public static IdCounter Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new IdCounter();
                        }
                    }
                }

                return instance;
            }
        }

        public int GetStudentId()
        {
            return studentCounter++;
        }

        public int GetTeacherId()
        {
            return teacherCounter++;
        }
    }
}
