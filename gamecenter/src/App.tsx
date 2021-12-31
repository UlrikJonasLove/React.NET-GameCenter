import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import LandingPage from './components/games/LandingPage';
import Menu from './components/games/Menu';
import Genres from './components/genres/Genres';
import routes from './route-config';

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