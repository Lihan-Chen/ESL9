namespace Mvc.ViewModels;

public sealed record LogFilterTransferDto(
    int? SelectedFacilNo,
    int? SelectedLogTypeNo,
    DateOnly? StartDate,
    DateOnly? EndDate,
    bool OperatorType,
    string? CurrentFilter);
