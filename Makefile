modname = CrusadersEquipment
gamepath = /mnt/c/Program\ Files\ \(x86\)/Steam/steamapps/common/Outward/Outward_Defed
pluginpath = BepInEx/plugins
sideloaderpath = $(pluginpath)/$(modname)/SideLoader
exports = resources/artsource/exports
unityassets = resources/unity/HolyAvengerBastard/Assets/AssetBundles

dependencies = HolyDamageManager TinyHelper CustomWeaponBehaviour EffectSourceConditions

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
	mkdir -p public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material
	cp -u resources/icons/basic_relic.png                      public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/icon.png
	cp -u $(exports)/basic_relic/_GenTex.png                   public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material/_GenTex.png
	cp -u $(exports)/basic_relic/_MainTex.png                  public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material/_MainTex.png
	cp -u $(exports)/basic_relic/_NormTex.png                  public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material/_NormTex.png
	cp -u $(exports)/basic_relic/_SpecColorTex.png             public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material/_SpecColorTex.png
	cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/GoldLichTalisman/Textures/basic_relic_Material/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material
	cp -u resources/icons/holy_avenger_no_inscription.png      public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/icon.png
	cp -u $(exports)/puresteel_longsword/_GenTex.png           public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_GenTex.png
	cp -u $(exports)/puresteel_longsword/_MainTex.png          public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_MainTex.png
	cp -u $(exports)/puresteel_longsword/_NormTex.png          public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_NormTex.png
	cp -u $(exports)/puresteel_longsword/_SpecColorTex.png     public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/_SpecColorTex.png
	cp -u resources/textures/properties_color_spec.xml         public/$(sideloaderpath)/Items/PuresteelLongsword/Textures/puresteel_longsword_Material/properties.xml
	mkdir -p public/$(sideloaderpath)/Items/HolyWater/Textures
	cp -u resources/icons/holy_water.png                       public/$(sideloaderpath)/Items/HolyWater/Textures/icon.png
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
	
	cp -u $(unityassets)/puresteel_longsword                   public/$(sideloaderpath)/AssetBundles/puresteel_longsword
	cp -u $(unityassets)/basic_relic                           public/$(sideloaderpath)/AssetBundles/basic_relic
	
publish:
	make assemble
	rm -f $(modname).rar
	rar a $(modname).rar -ep1 public/*

install:
	make assemble
	rm -r -f $(gamepath)/$(pluginpath)/$(modname)
	cp -u -r public/* $(gamepath)
clean:
	rm -f -r public
	rm -f $(modname).rar
	rm -f -r bin
info:
	echo Modname: $(modname)

unity:
	cp -u resources/artsource/puresteel_longsword.fbx                                  $(unityassets)/puresteel_longsword.fbx
	cp -u $(exports)/puresteel_longsword/puresteel_longsword_AlbedoTransparency.png    $(unityassets)/puresteel_longsword_AlbedoTransparency.png
	cp -u $(exports)/puresteel_longsword/puresteel_longsword_MetallicSmoothness.png    $(unityassets)/puresteel_longsword_MetallicSmoothness.png
	cp -u $(exports)/puresteel_longsword/puresteel_longsword_Normal.png                $(unityassets)/puresteel_longsword_Normal.png
play:
	(make install && cd .. && make play)
