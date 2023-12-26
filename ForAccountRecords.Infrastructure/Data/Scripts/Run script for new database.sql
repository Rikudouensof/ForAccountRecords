use ForAccountRecords

Insert into TransactionTypes values('Assets')
Insert into TransactionTypes values('Liabilities')
Insert into TransactionTypes values('Expenses')
Insert into TransactionTypes values('Revenue')
Insert into TransactionTypes values('Equity')
Insert into TransactionTypes values('Dividends')

Insert into TransactionClassifications values('Current Assets',1)
Insert into TransactionClassifications values('Fized or Non Current Assets',1)
Insert into TransactionClassifications values('Current Liabilities',2)
Insert into TransactionClassifications values('Non Current Liabilities',2)
Insert into TransactionClassifications values('Expenses',3)
Insert into TransactionClassifications values('Operating Revenue',4)
Insert into TransactionClassifications values('Non Operating Revenue',4)
Insert into TransactionClassifications values('Equity',5)
Insert into TransactionClassifications values('Dividends',6)

--Assets sub category
Insert into SubTransactionClassifications values('Cash and Cash Equivalents',1)
Insert into SubTransactionClassifications values('Accounts recievable',1)
Insert into SubTransactionClassifications values('Marketable Securities',1)
Insert into SubTransactionClassifications values('Inventory',1)
Insert into SubTransactionClassifications values('Short term investments',1)
Insert into SubTransactionClassifications values('Others',1)

Insert into SubTransactionClassifications values('Real Estate',2)
Insert into SubTransactionClassifications values('Patents',2)
Insert into SubTransactionClassifications values('Equipment',2)
Insert into SubTransactionClassifications values('Tools',2)
Insert into SubTransactionClassifications values('Machinery',2)
Insert into SubTransactionClassifications values('Furniture',2)
Insert into SubTransactionClassifications values('Others',2)

--Liabilities sub category
Insert into SubTransactionClassifications values('Accounts Payable',3)
Insert into SubTransactionClassifications values('Intrest Payable',3)
Insert into SubTransactionClassifications values('Income tax payable',3)
Insert into SubTransactionClassifications values('Bank account Overdrafts',3)
Insert into SubTransactionClassifications values('Accrued Expenses',3)
Insert into SubTransactionClassifications values('Deferred revenue',3)
Insert into SubTransactionClassifications values('Short term loans',3)
Insert into SubTransactionClassifications values('Current Portions of long term dept',3)
Insert into SubTransactionClassifications values('Others',3)

Insert into SubTransactionClassifications values('Bonds Payable',4)
Insert into SubTransactionClassifications values('Notes Payable',4)
Insert into SubTransactionClassifications values('Defred tax payable',4)
Insert into SubTransactionClassifications values('Mortguage payable',4)
Insert into SubTransactionClassifications values('Leases',4)
Insert into SubTransactionClassifications values('Others',4)

--Expenses sub category
Insert into SubTransactionClassifications values('Cost of goods sold',5)
Insert into SubTransactionClassifications values('Selling and distribution expenses',5)
Insert into SubTransactionClassifications values('Operating, General and administrative expenses',5)
Insert into SubTransactionClassifications values('Salaries, Wages and benefits',5)
Insert into SubTransactionClassifications values('Rent Expense',5)
Insert into SubTransactionClassifications values('Cost of utilities',5)
Insert into SubTransactionClassifications values('Provisions and impairments',5)
Insert into SubTransactionClassifications values('Amortization expense',5)
Insert into SubTransactionClassifications values('Research and development Cost',5)
Insert into SubTransactionClassifications values('Printing and stationary expense',5)
Insert into SubTransactionClassifications values('Staff travelling expense',5)
Insert into SubTransactionClassifications values('Repair and mentainance expense',5)
Insert into SubTransactionClassifications values('Insurance cost',5)
Insert into SubTransactionClassifications values('Legal and professional charges',5)
Insert into SubTransactionClassifications values('Communication expense',5)
Insert into SubTransactionClassifications values('Miscellaneous expense',5)
Insert into SubTransactionClassifications values('Finance Cost',5)
Insert into SubTransactionClassifications values('Taxation',5)
Insert into SubTransactionClassifications values('Others',5)

--Revenue sub category
Insert into SubTransactionClassifications values('Sales Revenue',6)
Insert into SubTransactionClassifications values('Rent Revenue',6)
Insert into SubTransactionClassifications values('Service Revenue',6)
Insert into SubTransactionClassifications values('Others',6)


Insert into SubTransactionClassifications values('Dividend Revenue',7)
Insert into SubTransactionClassifications values('Others',7)

--Equity sub category
Insert into SubTransactionClassifications values('Common stock',8)
Insert into SubTransactionClassifications values('Prefared Stock',8)
Insert into SubTransactionClassifications values('Aditional Pain-in Capital',8)
Insert into SubTransactionClassifications values('Contributed Supplus',8)
Insert into SubTransactionClassifications values('Retained Earnings',8)
Insert into SubTransactionClassifications values('Other Comprehensive Income',8)
Insert into SubTransactionClassifications values('Tresury Stock',8)
Insert into SubTransactionClassifications values('Others',8)

--Dividends sub category
Insert into SubTransactionClassifications values('Dividend',9)

--Entry Types
Insert into EntryTypes values('Credit')
Insert into EntryTypes values('Debit')