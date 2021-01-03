import React, { ReactElement } from 'react';
import Dashboard from './views/Dashboard';
import { AuthenticatedTemplate, UnauthenticatedTemplate, useMsal } from '@azure/msal-react';
import { AccountInfo } from '@azure/msal-browser';

function App(): ReactElement {
    const { instance, accounts, inProgress } = useMsal();
    const account: Partial<AccountInfo> = accounts[0] ? accounts[0] : {};
    return (
        <div className="App">
            <h1>hello</h1>
            <AuthenticatedTemplate>
                <h2>Welcome {account ? account.name : 'anon'}</h2>
                <Dashboard />
                <button onClick={() => instance.logout()}>Logout</button>
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <h1>Hello, please log in</h1>
                <button onClick={() => instance.loginPopup()}>Login</button>
            </UnauthenticatedTemplate>
        </div>
    );
}

export default App;
