// controllers/permissionController.js
const Role = require('../models/role');
const Permission = require('../models/permission');
const RolePermission = require('../models/rolePermission');

exports.addPermission = async (req, res) => {
  const { name } = req.body;

  try {
    const permission = await Permission.create({ name });
    res.status(201).json({ message: 'İzin oluşturuldu.', permission });
  } catch (error) {
    res.status(500).json({ message: 'Bir hata oluştu.', error });
  }
};

exports.assignPermission = async (req, res) => {
  const { roleId, permissionId } = req.body;

  try {
    const rolePermission = await RolePermission.create({ role_id: roleId, permission_id: permissionId });
    res.status(201).json({ message: 'İzin role atandı.', rolePermission });
  } catch (error) {
    res.status(500).json({ message: 'Bir hata oluştu.', error });
  }
};
    