INSERT INTO AspNetRoles (Id, Name) VALUES (1, 'Admin');
INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('45d1cc5b-62bb-4e70-94eb-b5daa950ffb9', 1);

select * from AspNetUserRoles;
select * from AspNetUsers;
select * from AspNetRoles;