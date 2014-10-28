

SET IDENTITY_INSERT [dbo].Contrast_UserInfo ON

INSERT INTO dbo.Contrast_UserInfo ( [ID], Name, Age,Privacies,LegalPerson,CompanyName,DemandMoney,DemandMonth,AcceptInterest ) VALUES  ( 1,'借款人一',35,'False','借款法人一','借款公司一',100,12,8)
INSERT INTO dbo.Contrast_UserInfo ( [ID], Name, Age,Privacies,LegalPerson,CompanyName,DemandMoney,DemandMonth ,AcceptInterest) VALUES  ( 2,'借款人二',28,'False','借款法人二','借款公司二',1000,12,9)
INSERT INTO dbo.Contrast_UserInfo ( [ID], Name, Age,Privacies,LegalPerson,CompanyName,DemandMoney,DemandMonth,AcceptInterest ) VALUES  ( 3,'借款人三',40,'True','借款法人三','借款公司三',500,6,7)
INSERT INTO dbo.Contrast_UserInfo ( [ID], Name, Age,Privacies,LegalPerson,CompanyName,DemandMoney,DemandMonth ,AcceptInterest) VALUES  ( 4,'借款人四',29,'False','借款法人四','借款公司四',300,9,10)
INSERT INTO dbo.Contrast_UserInfo ( [ID], Name, Age,Privacies,LegalPerson,CompanyName,DemandMoney,DemandMonth ,AcceptInterest) VALUES  ( 5,'借款人五',43,'True','借款法人五','借款公司五',2000,24,6)

SET IDENTITY_INSERT [dbo].Contrast_UserInfo OFF

-------------------------------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT [dbo].Contrast_Organization ON

--1级菜单---
INSERT INTO dbo.Contrast_Organization ( [ID], Name, Qualifications,Location,Credit,LegalPerson,Guarantee,ProvideMoney,BeginMonth,EndMonth, DemandInterest) VALUES  ( 1,'组织机构人一','资质一','西安','A','组织机构法人一','担保一',2000,6,32,7)
INSERT INTO dbo.Contrast_Organization ( [ID], Name, Qualifications,Location,Credit,LegalPerson,Guarantee,ProvideMoney,BeginMonth,EndMonth, DemandInterest) VALUES  ( 2,'组织机构人二','资质二','西安','A','组织机构法人二','担保二',500,6,24,10)
INSERT INTO dbo.Contrast_Organization ( [ID], Name, Qualifications,Location,Credit,LegalPerson,Guarantee,ProvideMoney,BeginMonth,EndMonth, DemandInterest) VALUES  ( 3,'组织机构人三','资质三','西安','A','组织机构法人三','担保三',100,9,12,9)

SET IDENTITY_INSERT [dbo].Contrast_Organization OFF
