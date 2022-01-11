import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import Menu from './components/games/Menu';
import routes from './route-config';
import configureValidations from './Validations';

configureValidations();

function App() {
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

export default App;