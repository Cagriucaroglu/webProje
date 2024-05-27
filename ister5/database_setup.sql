CREATE DATABASE gorev_yonetim;

USE gorev_yonetim;

CREATE TABLE roles (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role_id INT FOREIGN KEY REFERENCES roles(id)
);

CREATE TABLE permissions (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE role_permissions (
    role_id INT NOT NULL FOREIGN KEY REFERENCES roles(id),
    permission_id INT NOT NULL FOREIGN KEY REFERENCES permissions(id),
    PRIMARY KEY (role_id, permission_id)
);
