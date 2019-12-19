
--exec dbo.Pro_GetPageData 'Tencent_Subject_001','*','20','2','','Id','1'
 
--如果遇到有存储过程Pro_GetPageData  就先删除掉
if exists (select * from sysobjects where type = 'P' and name = 'Pro_GetPageData')
    drop procedure dbo.spStockTakingPaperList;
GO
 

 --创建存储过程
CREATE PROCEDURE [dbo].[Pro_GetPageData] 
 ( 
     @TableName        nvarchar(3000),            -- 表名 
     @ReturnFields    nvarchar(3000) = '*',    -- 需要返回的列  
     @PageSize        int = 10,                -- 每页记录数 
     @PageIndex        int = 0,                -- 当前页码 
     @Where            nvarchar(3000) = '',        -- 查询条件 
     @OrderBy        nvarchar(200),            -- 排序字段名 最好为唯一主键 
     @OrderType        int = 1                    -- 排序类型 1:降序 其它为升序 
 ) 
 AS 
     DECLARE @TotalRecord int 
     DECLARE @TotalPage int 
     DECLARE @CurrentPageSize int 
     DECLARE @TotalRecordForPageIndex int 
     declare @CountSql nvarchar(4000)  
   
     if @OrderType = 1 
         BEGIN 
             set @OrderBy = ' Order by ' + REPLACE(@OrderBy,',',' desc,') + ' desc ' 
         END 
     else 
         BEGIN 
             set @OrderBy = ' Order by ' + REPLACE(@OrderBy,',',' asc,') + ' asc '    
         END 
     -- 总记录 
     set @CountSql='SELECT @TotalRecord=Count(*) From '+@TableName+' '+@Where 
     execute sp_executesql @CountSql,N'@TotalRecord int out',@TotalRecord out 
     SET @TotalPage=(@TotalRecord-1)/@PageSize+1 
     -- 查询页数不得大于总页数 
     if(@PageIndex > @TotalPage) 
         set @PageIndex = @TotalPage 
     SET @CurrentPageSize=(@PageIndex-1)*@PageSize
   
     -- 返回记录
 
     set @TotalRecordForPageIndex=@PageIndex*@PageSize
  
     exec    ('SELECT *
 
             FROM (SELECT TOP '+@TotalRecordForPageIndex+' '+@ReturnFields+', ROW_NUMBER() OVER ('+@OrderBy+') AS ROWNUM
 
             FROM '+@TableName+ ' ' + @Where +' ) AS TempTable 
             WHERE TempTable.ROWNUM >  
             '+@CurrentPageSize) 
     -- 返回总页数和总记录 
     SELECT @TotalPage as PageCount,@TotalRecord as RecordCount