import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Menu } from './components/nav/Menu';
import { routes } from './components/nav/route-config';
import configureValidations from './Validations';

configureValidations();

export const App = () => {
  return (
    
    <BrowserRouter>
      <Menu />
        
        <div className='container'>
          <Switch>
            {routes.map(route=> 
            <Route key={route.path} path={route.path} exact={route.exact}>
              <route.component />
            </Route>)}
          </Switch>
        </div>  
    </BrowserRouter>
      
  )
}