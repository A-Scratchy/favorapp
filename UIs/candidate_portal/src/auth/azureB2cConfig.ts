import { Configuration } from '@azure/msal-browser';

// Check we have the correct env variables needed for auth
const clientId = process.env.REACT_APP_CLIENT_ID;
if (!clientId) {
    throw new Error('Please provide a client id in the env variables');
}

const authority = process.env.REACT_APP_AUTHORITY;
if (!authority) {
    throw new Error('Please provide an authority in the env variables');
}

const redirectUri = process.env.REACT_APP_REDIRECT_URI;
if (!redirectUri) {
    throw new Error('Please provide a redirectUri in the env variables');
}

const domain = process.env.REACT_APP_DOMAIN;
if (!domain) {
    throw new Error('Please provide a domain in the env variables');
}

// msal configuration object
const msalConfig: Configuration = {
    auth: {
        clientId: clientId || '',
        authority: authority,
        redirectUri: redirectUri,
        knownAuthorities: [domain],
        cloudDiscoveryMetadata: '',
        postLogoutRedirectUri: '',
        navigateToLoginRequestUrl: true,
        clientCapabilities: ['CP1'],
    },
    cache: {
        cacheLocation: 'sessionStorage',
        storeAuthStateInCookie: false,
    },
    system: {
        windowHashTimeout: 60000,
        iframeHashTimeout: 6000,
        loadFrameTimeout: 0,
        asyncPopups: false,
    },
};

export default msalConfig;
