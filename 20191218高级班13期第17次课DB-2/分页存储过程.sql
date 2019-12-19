
--exec dbo.Pro_GetPageData 'Tencent_Subject_001','*','20','2','','Id','1'
 
--��������д洢����Pro_GetPageData  ����ɾ����
if exists (select * from sysobjects where type = 'P' and name = 'Pro_GetPageData')
    drop procedure dbo.spStockTakingPaperList;
GO
 

 --�����洢����
CREATE PROCEDURE [dbo].[Pro_GetPageData] 
 ( 
     @TableName        nvarchar(3000),            -- ���� 
     @ReturnFields    nvarchar(3000) = '*',    -- ��Ҫ���ص���  
     @PageSize        int = 10,                -- ÿҳ��¼�� 
     @PageIndex        int = 0,                -- ��ǰҳ�� 
     @Where            nvarchar(3000) = '',        -- ��ѯ���� 
     @OrderBy        nvarchar(200),            -- �����ֶ��� ���ΪΨһ���� 
     @OrderType        int = 1                    -- �������� 1:���� ����Ϊ���� 
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
     -- �ܼ�¼ 
     set @CountSql='SELECT @TotalRecord=Count(*) From '+@TableName+' '+@Where 
     execute sp_executesql @CountSql,N'@TotalRecord int out',@TotalRecord out 
     SET @TotalPage=(@TotalRecord-1)/@PageSize+1 
     -- ��ѯҳ�����ô�����ҳ�� 
     if(@PageIndex > @TotalPage) 
         set @PageIndex = @TotalPage 
     SET @CurrentPageSize=(@PageIndex-1)*@PageSize
   
     -- ���ؼ�¼
 
     set @TotalRecordForPageIndex=@PageIndex*@PageSize
  
     exec    ('SELECT *
 
             FROM (SELECT TOP '+@TotalRecordForPageIndex+' '+@ReturnFields+', ROW_NUMBER() OVER ('+@OrderBy+') AS ROWNUM
 
             FROM '+@TableName+ ' ' + @Where +' ) AS TempTable 
             WHERE TempTable.ROWNUM >  
             '+@CurrentPageSize) 
     -- ������ҳ�����ܼ�¼ 
     SELECT @TotalPage as PageCount,@TotalRecord as RecordCount