import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Footer } from './components/shared/Footer';
import { Menu } from './components/shared/Menu';
import { routes } from './constants/route-config';
import configureValidations from './Validations';

configureValidations();

export const App = () => {
  return (
    <BrowserRouter>
      <Menu />
        <div className='container'>
          <Switch>
            {/* Map through all the routes */}
            {routes.map(route=> 
            <Route key={route.path} path={route.path} exact={route.exact}>
              <route.component />
            </Route>)}
          </Switch>
        </div>
        <Footer />
    </BrowserRouter>
  )
}