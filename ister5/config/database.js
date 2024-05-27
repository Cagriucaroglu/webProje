const { Sequelize } = require('sequelize');

const sequelize = new Sequelize('gorev_yonetim', 'root', 'password', {
  host: 'localhost',
  dialect: 'mysql'
});

module.exports = sequelize;
