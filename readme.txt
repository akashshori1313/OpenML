1. open project > BookStore > BookStore.sln

2. Use this command in Package manager console for database migration


Add-Migration NewMigration -Project BookStore.EFModels

Update-Database


3. for inserting new book record pass book_id as 0 ; for updating pass book_id same as book_id which you want to update book.

