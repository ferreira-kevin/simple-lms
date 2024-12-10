﻿using lms.Data.Repositories;
using lms.Domain;
using lms.Domain.Utils;

namespace lms.UseCases.Manager.AcademicRecord;

public interface ICreateStudent
{
    Task<string?> Execute(NewStudentForm studentForm);
}

public class CreateStudent(IStudentRepository studentRepository) : ICreateStudent
{
    public async Task<string?> Execute(NewStudentForm studentForm)
    {
        if (!studentForm.IsValid())
            return "Revise o formulário, existem dados inválidos.";
        var password = PasswordGenerator.GenerateStrongPassword(12);
        var student = studentForm.ToStudentModel(password);
        try
        {
            await studentRepository.AddAsync(student);
        }
        catch(Exception ex)
        {
            return "O serviço está indisponível no momento, se o erro persistir entre em contato com suporte.";
        }

        return default;
    }
}

public class NewStudentForm
{
    public string FullName { get; set; }
    public string EnrollmentNumber { get; set; }
    public string Identity { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateOnly BirthDate { get; set; }

    public NewStudentForm()
    {
        FullName = string.Empty;
        EnrollmentNumber = string.Empty;
        Identity = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        var defaultDate = DateTime.UtcNow.AddYears(-18);
        BirthDate = DateOnly.FromDateTime(defaultDate);
    }

    public bool IsValid() => !string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(EnrollmentNumber) && !string.IsNullOrWhiteSpace(Identity);

    public StudentModel ToStudentModel(string temporaryPassword) =>
        new StudentModel(EnrollmentNumber, FullName, Email, Identity, Phone, temporaryPassword, BirthDate);
}

//public StudentModel(string enrollmentNumber, string fullName, string email, string identity, string phone, string hashedPassword, DateOnly birthDate, AddressModel address)


    //public string Street { get; set; }
    //public string City { get; set; }
    //public string State { get; set; }
    //public string ZipCode { get; set; }
    //public string Country { get; set; }