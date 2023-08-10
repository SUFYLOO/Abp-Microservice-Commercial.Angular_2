import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44360/',
  redirectUri: baseUrl,
  clientId: 'Resume_App',
  responseType: 'code',
  scope: 'offline_access Resume',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Resume',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'Resume',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
