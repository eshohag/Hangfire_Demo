/*
	DROP TABLE [Hangfire_DB].[HangFire].[Job]
	DROP TABLE [Hangfire_DB].[HangFire].[AggregatedCounter]
	DROP TABLE [Hangfire_DB].[HangFire].[Counter]
	DROP TABLE [Hangfire_DB].[HangFire].[Hash]
	DROP TABLE [Hangfire_DB].[HangFire].[JobParameter]
	DROP TABLE [Hangfire_DB].[HangFire].[JobQueue]
	DROP TABLE [Hangfire_DB].[HangFire].[List]
	DROP TABLE [Hangfire_DB].[HangFire].[Schema]
	DROP TABLE [Hangfire_DB].[HangFire].[Server]
	DROP TABLE [Hangfire_DB].[HangFire].[Set]
	DROP TABLE [Hangfire_DB].[HangFire].[State]

*/

SELECT 'AggregatedCounter' AS TableName, * FROM [Hangfire_DB].[HangFire].[AggregatedCounter]
SELECT 'Counter' AS TableName,* FROM [Hangfire_DB].[HangFire].[Counter]
SELECT 'Hash' AS TableName,* FROM [Hangfire_DB].[HangFire].[Hash]
SELECT 'Job' AS TableName,* FROM [Hangfire_DB].[HangFire].[Job]
SELECT 'JobParameter' AS TableName,* FROM [Hangfire_DB].[HangFire].[JobParameter]
SELECT 'JobQueue' AS TableName,* FROM [Hangfire_DB].[HangFire].[JobQueue]
SELECT 'List' AS TableName,* FROM [Hangfire_DB].[HangFire].[List]
SELECT 'Schema' AS TableName,* FROM [Hangfire_DB].[HangFire].[Schema]
SELECT 'Server' AS TableName,* FROM [Hangfire_DB].[HangFire].[Server]
SELECT 'Set' AS TableName,* FROM [Hangfire_DB].[HangFire].[Set]
SELECT 'State' AS TableName,*  FROM [Hangfire_DB].[HangFire].[State]










