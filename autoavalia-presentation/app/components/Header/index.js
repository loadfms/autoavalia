import React, { Component } from 'react';
import brandWebmotors from '../../assets/images/brands/brand-webmotors-color.svg';

export default class Header extends Component {
	render() {
		return (
			<header className="header">
				<div className="container">
					<h1 className="header__brand">
						<a href="#">
							<img src={brandWebmotors} />					
						</a>
					</h1>
				</div>
			</header>
		);
	}
}