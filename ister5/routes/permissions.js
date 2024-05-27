// routes/permissions.js
const express = require('express');
const router = express.Router();
const permissionController = require('../controllers/permissionController');

router.post('/add', permissionController.addPermission);
router.post('/assign', permissionController.assignPermission);

module.exports = router;
