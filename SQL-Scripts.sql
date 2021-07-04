create user web_mail with password '123'

create database webmail owner web_mail

CREATE TABLE mails (
    id serial PRIMARY KEY,
    date date,
    body varchar,
    result varchar(10),
    failedmessage varchar,
    destination varchar(30)
);