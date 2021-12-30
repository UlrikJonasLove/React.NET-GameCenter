import { useEffect, useState } from 'react';
import './App.css';
import GamesList from './components/games/GamesList';
import { LandingPageDTO } from './components/games/interface/games.model';

function App() {

  const [Games, setGames] = useState<LandingPageDTO>({})

  useEffect(() => {
    const timerId = setTimeout(() => {
      setGames({
        newlyReleases: [{
          id: 1,
          title: "Red Dead Redemption 2",
          poster: "https://image.api.playstation.com/cdn/UP1004/CUSA03041_00/Hpl5MtwQgOVF9vJqlfui6SDB5Jl4oBSq.png"
        },
        {
          id: 2,
          title: "Red Dead Redemption 2",
          poster: "https://image.api.playstation.com/cdn/UP1004/CUSA03041_00/Hpl5MtwQgOVF9vJqlfui6SDB5Jl4oBSq.png"
        }],
        upcomingReleases: [{
          id: 3,
          title: "Red Dead Redemption 2",
          poster: "https://image.api.playstation.com/cdn/UP1004/CUSA03041_00/Hpl5MtwQgOVF9vJqlfui6SDB5Jl4oBSq.png"
        }]
      })
    }, 1000)

    return () => clearTimeout(timerId);
  })

  return (
    <div className='container'>
    <h3>Newly Releases</h3>
    <GamesList games={Games.newlyReleases}/>
    <h3>Upcoming Releases</h3>
    <GamesList games={Games.upcomingReleases}/>
    </div>
  )
}

export default App;