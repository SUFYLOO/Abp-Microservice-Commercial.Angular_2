import api from './API';

export function getUsageStatistics(params = {}) {
  return api
    .get('/api/saas/editions/statistics/usage-statistic', { params })
    .then(({ data }) => data);
}

export function getTenants(params = {}) {
  return api.get('/api/saas/tenants', { params }).then(({ data }) => data);
}

export function createTenant(body) {
  return api.post('/api/saas/tenants', body).then(({ data }) => data);
}

export function getTenantById(id) {
  return api.get(`/api/saas/tenants/${id}`).then(({ data }) => data);
}

export function updateTenant(body, id) {
  return api.put(`/api/saas/tenants/${id}`, body).then(({ data }) => data);
}

export function removeTenant(id) {
  return api.delete(`/api/saas/tenants/${id}`).then(({ data }) => data);
}

export function getEditions(params = {}) {
  return api.get('/api/saas/editions', { params }).then(({ data }) => data);
}
