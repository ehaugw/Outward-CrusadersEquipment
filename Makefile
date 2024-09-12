modname = CrusadersEquipment
gamepath = /mnt/c/Program\ Files\ \(x86\)/Steam/steamapps/common/Outward/Outward_Defed
pluginpath = BepInEx/plugins
sideloaderpath = $(pluginpath)/$(modname)/SideLoader
exports = resources/artsource/exports
unityassets = resources/unity/HolyAvengerBastard/Assets
unityassetbundles = resources/unity/HolyAvengerBastard/Assets/AssetBundles

dependencies = TinyQuests Proficiencies SynchronizedWorldObjects HolyDamageManager TinyHelper CustomWeaponBehaviour EffectSourceConditions ImpendingDoom

assemble:
	# common for all mods
	rm -f -r public
	mkdir -p public/$(pluginpath)/$(modname)
	cp -u bin/$(modname).dll public/$(pluginpath)/$(modname)/
	for dependency in $(dependencies) ; do \
		cp -u ../$${dependency}/bin/$${dependency}.dll public/$(pluginpath)/$(modname)/ ; \
	done
	
	# sideloader specific
	mkdir -p public/$(sideloaderpath)/Items
	mkdir -p public/$(sideloaderpath)/Texture2D
	mkdir -p public/$(sideloaderpath)/AssetBundles
	
	mkdir -p public/$(sideloaderpath)/Items/AdamantineIngot/Textures
	cp -u resources/icons/adamantine_ingot.png                 public/$(sideloaderpath)/Items/AdamantineIngot/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/AncientRelic/Textures
	cp -u resources/icons/ancient_relic.png                    public/$(sideloaderpath)/Items/AncientRelic/Textures/icon.png


	mkdir -p public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader
	cp -u resources/icons/ranger_boots.png                     public/$(sideloaderpath)/Items/RangerBoots/Textures/icon.png
	cp -u resources/textures/ranger_boots_gen.png              public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_GenTex.png
	cp -u resources/textures/ranger_boots_main.png             public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_MainTex.png
	cp -u resources/textures/ranger_boots_norm.png             public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_NormTex.png
	cp -u resources/textures/ranger_boots_det_norm.png         public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_DetNormTex.png
	cp -u resources/textures/ranger_boots_det_mask.png         public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_DetMaskTex.png
	cp -u resources/textures/ranger_boots_spec_color.png       public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/_SpecColorTex.png
	cp -u resources/textures/ranger_boots.xml                  public/$(sideloaderpath)/Items/RangerBoots/Textures/mat_cha_masterTrader/properties.xml

	mkdir -p public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor
	cp -u resources/icons/wolf_ranger_armor.png                public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/icon.png
	cp -u resources/textures/wolf_ranger_armor_gen.png         public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor/_GenTex.png
	cp -u resources/textures/wolf_ranger_armor_main.png        public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor/_MainTex.png
	cp -u resources/textures/wolf_ranger_armor_norm.png        public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor/_NormTex.png
	cp -u resources/textures/wolf_ranger_armor_spec_color.png  public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor/_SpecColorTex.png
	cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/WolfRangerArmor/Textures/mat_cha_WolfBattleMedicArmor/properties.xml

	mkdir -p public/$(sideloaderpath)/Items/RangersHood/Textures/mat_cha_beggarMaleArmorA
	cp -u resources/icons/ranger_hood.png                      public/$(sideloaderpath)/Items/RangersHood/Textures/icon.png
	cp -u resources/textures/ranger_hood_gen.png               public/$(sideloaderpath)/Items/RangersHood/Textures/mat_cha_beggarMaleArmorA/_GenTex.png
	cp -u resources/textures/ranger_hood_main.png              public/$(sideloaderpath)/Items/RangersHood/Textures/mat_cha_beggarMaleArmorA/_MainTex.png
	cp -u resources/textures/ranger_hood_norm.png              public/$(sideloaderpath)/Items/RangersHood/Textures/mat_cha_beggarMaleArmorA/_NormTex.png
	cp -u resources/textures/ranger_hood.xml                   public/$(sideloaderpath)/Items/RangersHood/Textures/mat_cha_beggarMaleArmorA/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/mat_cha_runicArmor
	cp -u resources/icons/crusaders_plate_armor.png            public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/icon.png
	cp -u resources/textures/crusaders_plate_armor_gen.png     public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/mat_cha_runicArmor/_GenTex.png
	cp -u resources/textures/crusaders_plate_armor_main.png    public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/mat_cha_runicArmor/_MainTex.png
	cp -u resources/textures/crusaders_plate_armor_norm.png    public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/mat_cha_runicArmor/_NormTex.png
	cp -u resources/textures/crusaders_plate_armor.xml         public/$(sideloaderpath)/Items/CrusadersPlateArmor/Textures/mat_cha_runicArmor/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersArmor/Textures/mat_cha_armorKaziteA
	cp -u resources/icons/crusaders_armor.png                  public/$(sideloaderpath)/Items/CrusadersArmor/Textures/icon.png
	cp -u resources/textures/crusaders_armor_gen.png           public/$(sideloaderpath)/Items/CrusadersArmor/Textures/mat_cha_armorKaziteA/_GenTex.png
	cp -u resources/textures/crusaders_armor_main.png          public/$(sideloaderpath)/Items/CrusadersArmor/Textures/mat_cha_armorKaziteA/_MainTex.png
	cp -u resources/textures/crusaders_armor.xml               public/$(sideloaderpath)/Items/CrusadersArmor/Textures/mat_cha_armorKaziteA/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersBoots/Textures/mat_cha_whitePriestArmor
	cp -u resources/icons/crusaders_boots.png                  public/$(sideloaderpath)/Items/CrusadersBoots/Textures/icon.png
	cp -u resources/textures/crusaders_boots_gen.png           public/$(sideloaderpath)/Items/CrusadersBoots/Textures/mat_cha_whitePriestArmor/_GenTex.png
	cp -u resources/textures/crusaders_boots_main.png          public/$(sideloaderpath)/Items/CrusadersBoots/Textures/mat_cha_whitePriestArmor/_MainTex.png
	cp -u resources/textures/crusaders_boots_norm.png          public/$(sideloaderpath)/Items/CrusadersBoots/Textures/mat_cha_whitePriestArmor/_NormTex.png
	cp -u resources/textures/crusaders_boots.xml               public/$(sideloaderpath)/Items/CrusadersBoots/Textures/mat_cha_whitePriestArmor/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersHood/Textures/mat_cha_beggarMaleArmorA
	cp -u resources/icons/crusaders_hood.png                   public/$(sideloaderpath)/Items/CrusadersHood/Textures/icon.png
	cp -u resources/textures/crusaders_hood_gen.png            public/$(sideloaderpath)/Items/CrusadersHood/Textures/mat_cha_beggarMaleArmorA/_GenTex.png
	cp -u resources/textures/crusaders_hood_main.png           public/$(sideloaderpath)/Items/CrusadersHood/Textures/mat_cha_beggarMaleArmorA/_MainTex.png
	cp -u resources/textures/crusaders_hood_norm.png           public/$(sideloaderpath)/Items/CrusadersHood/Textures/mat_cha_beggarMaleArmorA/_NormTex.png
	cp -u resources/textures/crusaders_hood.xml                public/$(sideloaderpath)/Items/CrusadersHood/Textures/mat_cha_beggarMaleArmorA/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersRoundShield/Textures/mat_itm_boneWeapons
	cp -u resources/icons/crusaders_round_shield.png           public/$(sideloaderpath)/Items/CrusadersRoundShield/Textures/icon.png
	cp -u resources/textures/crusaders_round_shield_main.png   public/$(sideloaderpath)/Items/CrusadersRoundShield/Textures/mat_itm_boneWeapons/_MainTex.png
	cp -u resources/textures/crusaders_round_shield.xml        public/$(sideloaderpath)/Items/CrusadersRoundShield/Textures/mat_itm_boneWeapons/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/CrusadersShield/Textures/mat_cha_crimsonPlateArmor
	cp -u resources/icons/crusaders_shield.png                 public/$(sideloaderpath)/Items/CrusadersShield/Textures/icon.png
	cp -u resources/textures/crusaders_shield_main.png         public/$(sideloaderpath)/Items/CrusadersShield/Textures/mat_cha_crimsonPlateArmor/_MainTex.png
	cp -u resources/textures/crusaders_shield.xml              public/$(sideloaderpath)/Items/CrusadersShield/Textures/mat_cha_crimsonPlateArmor/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain
	cp -u resources/icons/heavy_plate_armor.png                public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/icon.png
	cp -u $(exports)/heavy_plate_armor/_GenTex.png             public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain/_GenTex.png
	cp -u $(exports)/heavy_plate_armor/_MainTex.png            public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain/_MainTex.png
	cp -u $(exports)/heavy_plate_armor/_NormTex.png            public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain/_NormTex.png
	cp -u $(exports)/heavy_plate_armor/_SpecColorTex.png       public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain/_SpecColorTex.png
	cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/HeavyPlateArmor/Textures/mat_cha_plateArmorPlain/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/GoldRing/Textures/
	cp -u resources/icons/gold_ring.png                        public/$(sideloaderpath)/Items/GoldRing/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/FaraamHelmet/Textures/
	cp -u resources/icons/faraam_helmet.png                    public/$(sideloaderpath)/Items/FaraamHelmet/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/FaraamLongsword/Textures/
	cp -u resources/icons/faraam_longsword.png                 public/$(sideloaderpath)/Items/FaraamLongsword/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/corruptedLongsword/Textures/ #corrupted_longsword_Material
	cp -u resources/icons/corrupted_longsword.png              public/$(sideloaderpath)/Items/corruptedLongsword/Textures/icon.png
	# cp -u $(exports)/corrupted_longsword/_GenTex.png           public/$(sideloaderpath)/Items/corruptedLongsword/Textures/corrupted_longsword_Material/_GenTex.png
	# cp -u $(exports)/corrupted_longsword/_MainTex.png          public/$(sideloaderpath)/Items/corruptedLongsword/Textures/corrupted_longsword_Material/_MainTex.png
	# cp -u $(exports)/corrupted_longsword/_NormTex.png          public/$(sideloaderpath)/Items/corruptedLongsword/Textures/corrupted_longsword_Material/_NormTex.png
	# cp -u $(exports)/corrupted_longsword/_SpecColorTex.png     public/$(sideloaderpath)/Items/corruptedLongsword/Textures/corrupted_longsword_Material/_SpecColorTex.png
	# cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/corruptedLongsword/Textures/corrupted_longsword_Material/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/ #puresteel_longsword_Material
	cp -u resources/icons/holy_avenger_no_inscription.png      public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/icon.png
	# cp -u $(exports)/puresteel_longsword/_GenTex.png           public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_GenTex.png
	# cp -u $(exports)/puresteel_longsword/_MainTex.png          public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_MainTex.png
	# cp -u $(exports)/puresteel_longsword/_NormTex.png          public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_NormTex.png
	# cp -u $(exports)/puresteel_longsword/_SpecColorTex.png     public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_SpecColorTex.png
	# cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/HolyWater/Textures
	cp -u resources/icons/holy_water.png                       public/$(sideloaderpath)/Items/HolyWater/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/SoulIncense/Textures/mat_env_propSlimeVilePus
	cp -u resources/icons/soul_incense.png                     public/$(sideloaderpath)/Items/SoulIncense/Textures/icon.png
	mkdir -p public/$(sideloaderpath)/Items/ThickWhitePaint/Textures/mat_env_propSlimeVilePus
	cp -u resources/icons/thick_white_paint.png                public/$(sideloaderpath)/Items/ThickWhitePaint/Textures/icon.png
	cp -u resources/textures/thick_white_paint_main.png        public/$(sideloaderpath)/Items/ThickWhitePaint/Textures/mat_env_propSlimeVilePus/_MainTex.png
	cp -u resources/textures/thick_white_paint.xml             public/$(sideloaderpath)/Items/ThickWhitePaint/Textures/mat_env_propSlimeVilePus/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor
	cp -u resources/icons/zealots_armor.png                    public/$(sideloaderpath)/Items/ZealotsArmor/Textures/icon.png
	cp -u resources/textures/zealots_armor_gen.png             public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/_GenTex.png
	cp -u resources/textures/zealots_armor_main.png            public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/_MainTex.png
	cp -u resources/textures/zealots_armor_norm.png            public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/_NormTex.png
	cp -u resources/textures/zealots_armor_spec.png            public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/_SpecColorTex.png
	cp -u resources/textures/zealots_armor_glow.png            public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/_EmissionTex.png
	cp -u resources/textures/zealots_armor.xml                 public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/properties.xml
	cp -u resources/textures/zealots_armor_glow.xml            public/$(sideloaderpath)/Items/ZealotsArmor/Textures/mat_cha_krypteiaarmor/properties\ -\ Glow.xml

	cp -u ../ImpendingDoom/resources/textures/impendingDoomIcon.png             public/$(sideloaderpath)/Texture2D/
	
	cp -u $(unityassetbundles)/faraam_longsword                                       	public/$(sideloaderpath)/AssetBundles/faraam_longsword
	cp -u $(unityassetbundles)/faraam_helmet                                          	public/$(sideloaderpath)/AssetBundles/faraam_helmet
	cp -u $(unityassetbundles)/corrupted_longsword                                     	public/$(sideloaderpath)/AssetBundles/corrupted_longsword
	cp -u $(unityassetbundles)/puresteel_longsword                                     	public/$(sideloaderpath)/AssetBundles/puresteel_longsword
	cp -u $(unityassetbundles)/gold_ring                                                public/$(sideloaderpath)/AssetBundles/gold_ring

unity:
	cp resources/artsource/puresteel_longsword.fbx                                  $(unityassets)/puresteel_longsword.fbx
	cp resources/artsource/faraam_longsword.fbx                                     $(unityassets)/faraam_longsword.fbx
	cp resources/artsource/faraam_helmet.fbx                                        $(unityassets)/faraam_helmet.fbx
	cp resources/artsource/corrupted_longsword.fbx                                  $(unityassets)/corrupted_longsword.fbx
	cp resources/artsource/gold_ring.fbx                                            $(unityassets)/gold_ring.fbx
	cp $(exports)/faraam_longsword/faraam_longsword_AlbedoTransparency.png          $(unityassets)/faraam_longsword_AlbedoTransparency.png
	cp $(exports)/faraam_longsword/faraam_longsword_MetallicSmoothness.png          $(unityassets)/faraam_longsword_MetallicSmoothness.png
	cp $(exports)/faraam_longsword/faraam_longsword_Normal.png                      $(unityassets)/faraam_longsword_Normal.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_AlbedoTransparency.png    $(unityassets)/corrupted_longsword_AlbedoTransparency.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_MetallicSmoothness.png    $(unityassets)/corrupted_longsword_MetallicSmoothness.png
	cp $(exports)/corrupted_longsword/corrupted_longsword_Normal.png                $(unityassets)/corrupted_longsword_Normal.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_AlbedoTransparency.png    $(unityassets)/puresteel_longsword_AlbedoTransparency.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_MetallicSmoothness.png    $(unityassets)/puresteel_longsword_MetallicSmoothness.png
	cp $(exports)/puresteel_longsword/puresteel_longsword_Normal.png                $(unityassets)/puresteel_longsword_Normal.png
	cp $(exports)/gold_ring/gold_ring_AlbedoTransparency.png                        $(unityassets)/gold_ring_AlbedoTransparency.png
	cp $(exports)/gold_ring/gold_ring_MetallicSmoothness.png                        $(unityassets)/gold_ring_MetallicSmoothness.png
	cp $(exports)/gold_ring/gold_ring_Normal.png                                    $(unityassets)/gold_ring_Normal.png
	
publish:
	make backup
	make clean
	make assemble
	rar a $(modname).rar -ep1 public/*
	
	cp -r public/BepInEx thunderstore
	mv thunderstore/plugins/$(modname)/* thunderstore/plugins
	rmdir thunderstore/plugins/$(modname)
	
	(cd ../Descriptions && python3 $(modname).py)
	
	cp -u resources/manifest.json thunderstore/
	cp -u README.md thunderstore/
	cp -u resources/icon.png thunderstore/
	(cd thunderstore && zip -r $(modname)_thunderstore.zip *)
	cp -u ../tcli/thunderstore.toml thunderstore
	(cd thunderstore && tcli publish --file $(modname)_thunderstore.zip) || true
	mv thunderstore/$(modname)_thunderstore.zip .

install:
	make assemble
	rm -r -f $(gamepath)/$(pluginpath)/$(modname)
	cp -u -r public/* $(gamepath)
clean:
	rm -f -r public
	rm -f -r thunderstore
	rm -f $(modname).rar
	rm -f $(modname)_thunderstore.zip
	rm -f resources/manifest.json
	rm -f README.md
info:
	echo Modname: $(modname)
play:
	(make install && cd .. && make play)
edit:
	nvim ../Descriptions/$(modname).py
readme:
	(cd ../Descriptions/ && python3 $(modname).py)
backup:
	mkdir -p ../../OutwardModdingGraphicsBackup/resources/artsource
	mkdir -p ../../OutwardModdingGraphicsBackup/resources/icons
	cp -u resources/artsource/*.blend ../../OutwardModdingGraphicsBackup/resources/artsource
	cp -u resources/artsource/*.spp ../../OutwardModdingGraphicsBackup/resources/artsource
	cp -u resources/icons/*.pdn ../../OutwardModdingGraphicsBackup/resources/icons
