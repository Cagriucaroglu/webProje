console.log("asdasd");
const express = require('express');
const sequelize = require('./config/database');
const Role = require('./models/role');
const User = require('./models/user');
const Permission = require('./models/permission');
const RolePermission = require('./models/rolePermission');

const authRoutes = require('./routes/auth');
const permissionRoutes = require('./routes/permissions');

const app = express();

app.use(express.json());
app.use('/auth', authRoutes);
app.use('/permissions', permissionRoutes);

sequelize.sync().then(() => {
  console.log('Veritabanı senkronize edildi.');
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Sunucu ${PORT} portunda çalışıyor.`);
});
