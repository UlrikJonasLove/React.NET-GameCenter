import { useEffect, useState } from "react";
import { GamesList } from "./GamesList";
import { LandingPageDto } from "./models/games.model";

export const LandingPage = () =>{

    document.title = "Game Center - Home"
    const [Games, setGames] = useState<LandingPageDto>({})

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
    return(
        <>
            <h3>Newly Releases</h3>
            <GamesList games={Games.newlyReleases}/>

            <h3>Upcoming Releases</h3>
            <GamesList games={Games.upcomingReleases}/>
        </>
    )
}