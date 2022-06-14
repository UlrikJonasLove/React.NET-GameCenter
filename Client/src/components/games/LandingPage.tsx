import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { UrlGames } from "../../constants/endpoints";
import { GamesList } from "./GamesList";
import { LandingPageDto } from "./models/games.model";

export const LandingPage = () =>{

    document.title = "Game Center - Home"
    const [Games, setGames] = useState<LandingPageDto>({})

  useEffect(() => {
    axios.get(UrlGames).then((response: AxiosResponse<LandingPageDto>) => {
        setGames(response.data)
    })
  }, [])
    return(
        <>
            <h3>Newly Releases</h3>
            <GamesList games={Games.newlyReleases}/>

            <h3>Upcoming Releases</h3>
            <GamesList games={Games.upcomingReleases}/>
        </>
    )
}