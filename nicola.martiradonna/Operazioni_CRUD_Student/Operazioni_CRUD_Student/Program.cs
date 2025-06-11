
using Operazioni_CRUD_Student;
using Operazioni_CRUD_Student.Interfaces;
using Operazioni_CRUD_Student.Repos;

IStudentRepository databaseStudent = new StudentRepository();

int sceltaUtente;

do
{
    do
    {
        Console.WriteLine("\n\n1)Seleziona tutti gli studenti\n2)Seleziona studente per id \n3)Crea un nuovo studente \n4)Modifica uno studente per id\n5)Elimina studente per id");
        sceltaUtente = Convert.ToInt32(Console.ReadLine());
    } while (sceltaUtente < 1 || sceltaUtente > 5);
    switch (sceltaUtente)
    {
        case 1:
            SelectAllStudent();
            break;
        case 2:
            SelectStudentById();
            break;
        case 3:
            CreateNewStudent();
            break;
        case 4:
            UpdateStudent();
            break;
        case 5:
            DeleteStudent();
            break;


    }
} while (true);

void SelectAllStudent()
{
    Console.WriteLine("SELECT DI TUTTI GLI STUDENTI");
    Console.WriteLine($"\n\n!!       Esito Query Cerca tutti gli studenti: {databaseStudent.SelectAllStudent()}       !!");
}

void SelectStudentById()
{
    Console.WriteLine("\n SELECT DI TUTTI GLI STUDENTI CON UN ID SPECIFICO\n");
    int id=0;
    try
    {
        Console.WriteLine("Inserisci l' id\n");
        id = Convert.ToInt32(Console.ReadLine());
    }
    catch(FormatException ex)
    {
        Console.WriteLine("Formato Sbagliato");
        SelectStudentById();
    }
    Console.WriteLine($"\n\n!!       Esito Query cerca studente per id: {databaseStudent.SelectStudentById(id)}       !!");
}
void CreateNewStudent()
{
    Console.WriteLine("\n CREAZIONE DI UN NUOVO STUDENTE\n");

    Student student = new Student();

    try
    {
        Console.WriteLine("Inserisci l' id dello studente");
        student.Id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Inserisci il nome dello studente");
        student.Name = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome dello studente");
        student.Surname = Console.ReadLine();

        Console.WriteLine("Inserisci l' età dello studente");
        student.Age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Inserisci la nazione dello studente");
        student.Country = Console.ReadLine();
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Formato Sbagliato");
        CreateNewStudent();
    }

    Console.WriteLine($"\n\n!!       Esito Query Crea nuovo studente: {databaseStudent.CreateNewStudent(student)}        !!");
}
void UpdateStudent()
{
    Console.WriteLine("MODIFICA DI UNO STUDENTE");
    Student updatedStudent = new Student();
    int idUpdate=0;
    try
    {
        Console.WriteLine("Inserisci l' id dello studente di cui vuoi eseguire la modifica");
        idUpdate = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Formato Sbagliato");
        UpdateStudent();
    }

    try
    {
        Console.WriteLine("Inserisci l' id nuovo dello studente");
        updatedStudent.Id = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Formato Sbagliato");
        UpdateStudent();
    }

    Console.WriteLine("Inserisci il nome dello studente");
    updatedStudent.Name = Console.ReadLine();

    Console.WriteLine("Inserisci il cognome dello studente");
    updatedStudent.Surname = Console.ReadLine();

    Console.WriteLine("Inserisci l' età dello studente");
    updatedStudent.Age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci la nazione dello studente");
    updatedStudent.Country = Console.ReadLine();
    
    Console.WriteLine($"\n\n!!       Esito Query Update Student: {databaseStudent.UpdateStudent(idUpdate, updatedStudent)}       !!");
}
void DeleteStudent()
{
    int idElimina=0;
    try
    {
        Console.WriteLine("Inserisci l' id dello student che vuoi eliminare");
        idElimina = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Formato Sbagliato");
        DeleteStudent();
    }
    Console.WriteLine($"\n\n!!       Esito Query delete: {databaseStudent.DeleteStudentById(idElimina)}       !!");
}