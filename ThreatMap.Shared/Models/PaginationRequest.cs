﻿namespace ThreatMap.Shared.Models;

public class PaginationRequest
{
    private int _pageNumber;
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? value : 1;
    }

    private int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1 ? value : 25;
    }

    public PaginationRequest()
    {
        _pageNumber = 1;
        _pageSize = 25;
    }

    public PaginationRequest(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}