import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { MsalProvider } from '@azure/msal-react';
import { PublicClientApplication } from '@azure/msal-browser';

import msalConfig from './auth/azureB2cConfig';

const pca = new PublicClientApplication(msalConfig);

ReactDOM.render(
    <React.StrictMode>
        <MsalProvider instance={pca}>
            <App />
        </MsalProvider>
    </React.StrictMode>,
    document.getElementById('root'),
);
