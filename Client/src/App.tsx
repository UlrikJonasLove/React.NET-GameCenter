import { useEffect, useState } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Footer } from './components/shared/Footer';
import { Menu } from './components/shared/Menu';
import { RedirectToLandingPage } from './components/utils/RedirectToLandingPage';
import { routes } from './constants/route-config';
import { AuthContext } from './helpers/auth/authContext';
import { getClaim } from './helpers/auth/handleJwt';
import { configureInterceptor } from './helpers/http/httpInterceptor';
import { claim } from './models/auth/auth.models';
import configureValidations from './Validations';

configureValidations();
configureInterceptor();

export const App = () => {

  const [claims, setClaims] = useState<claim[]>([]);

  useEffect(() => {
    setClaims(getClaim());
  }, [])
  // isAdmin is true if the user has the role "admin"
  // it is greater than -1 if the role is found
  const isAdmin = () => {
    return claims.findIndex(claim => claim.name === 'role' && claim.value === 'admin') > -1;
  }

  return (
    <BrowserRouter>
    <AuthContext.Provider value={{claims, update: setClaims}}>
      <Menu />
        <div className='container'>
          <Switch>
            {/* Map through all the routes */}
            {routes.map(route=> 
            <Route key={route.path} path={route.path} exact={route.exact}>
              {/* checks if this route is protected with isAdmin and if the user is NOT an admin, redirect to landing page
              other wise the routes will be available  */}
              {route.isAdmin && !isAdmin() ? 
                <RedirectToLandingPage /> : <route.component />}
            </Route>)}
          </Switch>
        </div>
        <Footer />
    </AuthContext.Provider>
    </BrowserRouter>
  )
}