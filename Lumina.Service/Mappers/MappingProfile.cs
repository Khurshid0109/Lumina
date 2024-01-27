using AutoMapper;
using Lumina.Domain.Entities;
using Lumina.Service.DTOs.Users;
using Lumina.Service.DTOs.Courses;
using Lumina.Service.DTOs.Teachers;
using Lumina.Service.DTOs.StudyCenters;

namespace Lumina.Service.Mappers;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        // User DTOs
        CreateMap<UserPostModel, User>().ReverseMap();
        CreateMap<UserPutModel, User>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();

        // StudyCenter DTOs
        CreateMap<StudyCenterPostModel, StudyCenter>().ReverseMap();
        CreateMap<StudyCenterPutModel, StudyCenter>().ReverseMap();
        CreateMap<StudyCenterViewModel, StudyCenter>().ReverseMap();

        // Course
        CreateMap<CoursePostModel,Course>().ReverseMap();
        CreateMap<CoursePutModel,Course>().ReverseMap();
        CreateMap<CourseViewModel,Course>().ReverseMap();

        // Teacher
        CreateMap<TeacherPostModel,Teacher>().ReverseMap();
        CreateMap<TeacherPutModel, Teacher>().ReverseMap();
        CreateMap<TeacherViewModel, Teacher>().ReverseMap();
    }
}
