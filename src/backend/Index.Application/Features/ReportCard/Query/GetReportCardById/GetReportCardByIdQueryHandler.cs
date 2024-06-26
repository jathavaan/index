﻿namespace Index.Application.Features.ReportCard.Query.GetReportCardById;

public class GetReportCardByIdQueryHandler(IReportCardService reportCardService)
    : IRequestHandler<GetReportCardByIdQuery, Response<ReportCardVm>>
{
    public async Task<Response<ReportCardVm>> Handle(GetReportCardByIdQuery request,
        CancellationToken cancellationToken)
    {
        var reportCard = await reportCardService.GetReportCard(request.Id);

        if (reportCard is null)
        {
            return new Response<ReportCardVm>
            {
                ErrorCode = IndexErrorCode.NotFound,
                Error = $"Could not find report card with id {request.Id}"
            };
        }

        var gpa = await reportCardService.GetReportCardGpa(reportCard);
        var totalCredits = reportCardService.GetReportCardTotalCredits(reportCard);

        var result = new ReportCardVm
        {
            ReportCardId = reportCard.Id,
            Name = reportCard.Name,
            Subjects = reportCard.ReportCardSubjects
                .Select(rcs => new SubjectWithGradeVm
                {
                    SubjectCode = rcs.Subject.SubjectCode,
                    SubjectName = rcs.Subject.Name,
                    Year = rcs.Year,
                    Semester = rcs.Semester,
                    Credit = rcs.Subject.Credits,
                    Grade = rcs.Grade
                })
                .ToList(),
            TotalCredits = totalCredits,
            Gpa = gpa
        };

        return new Response<ReportCardVm>
        {
            Result = result
        };
    }
}