import { Box } from 'native-base';
import React from 'react';
import { usePermission } from '../../hooks/UsePermission';
import HostDashboard from './HostDashboard';
import TenantDashboard from './TenantDashboard';

function DashboardScreen() {
  const host = usePermission('Resume.Dashboard.Host');
  return (
    <Box px="7">
      {host ? <HostDashboard /> : <TenantDashboard />}
    </Box>
  );
}

export default DashboardScreen;
