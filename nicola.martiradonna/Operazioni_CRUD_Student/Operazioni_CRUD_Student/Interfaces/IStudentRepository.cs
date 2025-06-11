using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operazioni_CRUD_Student.Interfaces
{
    public interface IStudentRepository
    {
        bool SelectAllStudent();

        bool SelectStudentById(int id);

        bool CreateNewStudent(Student student);//INSERT

        bool UpdateStudent(int id,Student student);

        bool DeleteStudentById(int id);
    }
}
