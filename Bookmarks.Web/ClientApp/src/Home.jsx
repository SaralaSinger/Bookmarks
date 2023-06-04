import React, { useState, useEffect } from 'react';
import PopularLinkRow from './PopularLinkRow';
import axios from 'axios';

const Home = () => {
    const [popularLinks, setPopularLinks] = useState([]);

    useEffect(() => {
        getPopularLinks();
    }, []);

    const getPopularLinks = async () => {
        const { data } = await axios.get('/api/bookmark/getpopularlinks')
        setPopularLinks(data)
    }

    return (
        <div className="container" style={{ marginTop: 80 }}>
            <main role="main" className="pb-3">
                <div>
                    <h1>Welcome to the React Bookmark Application.</h1>
                    <h3>Top 5 most bookmarked links</h3>
                    <table className="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Url</th>
                                <th>Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {popularLinks.map(link => <PopularLinkRow
                                key={link.url}
                                link={link}
                            />)}
                        </tbody>
                    </table>
                </div>
            </main>
        </div>

    )
}
export default Home;