import { Link } from "react-router-dom"

export default function FilterGame() {
    document.title = "Game Center - Search"
    return(
        <>
            <h3>Search</h3>
            <Link className="btn btn-primary" to="/gamecenters/create">Create Game Center</Link>
        </>
    )
}