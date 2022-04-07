import { Link } from "react-router-dom"

export const GameCenters = () => {
    document.title = "Game Center - Game Centers"
    return(
        <>
            <h3>Game Centers</h3>
            <Link className="btn btn-primary" to="/gamecenters/create">Create Game Center</Link>
        </>
    )
}