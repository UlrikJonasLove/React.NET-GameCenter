import { CreateGenre } from "../components/genres/CreateGenre";
import { EditGenre } from "../components/genres/EditGenre";
import { Genres } from "../components/genres/Genres";

import { Actors } from "../components/actors/Actors";
import { CreateActor } from "../components/actors/CreateActor";
import { EditActor } from "../components/actors/EditActor";

import { GameCenters } from "../components/gamecenters/GameCenters";
import { CreateGameCenter } from "../components/gamecenters/CreateGameCenter";
import { EditGameCenter } from "../components/gamecenters/EditGameCenter";

import { LandingPage } from "../components/games/LandingPage";
import { FilterGame } from "../components/games/FilterGame";
import { CreateGame } from "../components/games/CreateGame";
import { EditGame } from "../components/games/EditGame";

import { RedirectToLandingPage } from "../components/utils/RedirectToLandingPage";
import { GameDetails } from "../components/games/GameDetails";
import { Register } from "../components/auth/Register";
import { Login } from "../components/auth/Login";

export const routes = [
    {path: "/genres", component: Genres, exact: true, isAdmin: true},
    {path: "/genres/create", component: CreateGenre, isAdmin: true},
    {path: "/genres/edit/:id(\\d+)", component: EditGenre, isAdmin: true},

    {path: "/actors", component: Actors, exact: true, isAdmin: true},
    {path: "/actors/create", component: CreateActor, isAdmin: true},
    {path: "/actors/edit/:id(\\d+)", component: EditActor, isAdmin: true},

    {path: "/gamecenters", component: GameCenters, exact: true, isAdmin: true},
    {path: "/gamecenters/create", component: CreateGameCenter, isAdmin: true},
    {path: "/gamecenters/edit/:id(\\d+)", component: EditGameCenter, isAdmin: true},

    {path: "/games/search", component: FilterGame},
    {path: "/game/create", component: CreateGame, isAdmin: true},
    {path: "/game/edit/:id(\\d+)", component: EditGame, isAdmin: true},
    {path: "/game/:id(\\d+)", component: GameDetails},

    {path: "/sign-up", component: Register},
    {path: "/sign-in", component: Login},

    {path: "/", component: LandingPage, exact: true},
    {path: "*", component: RedirectToLandingPage}
];